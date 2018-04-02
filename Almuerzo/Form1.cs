using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;

namespace Almuerzo
{
  public partial class Form1 : Form
  {
    private const int NamesStartIndex = 4;

    static string[] Scopes = { SheetsService.Scope.Spreadsheets };
    static string ApplicationName = "Google Sheets API .NET Quickstart";
    private static string PredefinedFoodDoc = "1GSXklTF_v_h918zluRpxXJfbggM7j_fjRbYDSWvlhyw";
    private List<Food> _foods;
    private int _maxOrderDay = 6;
    private string _name;

    private static readonly string PredefinedFoodDocEditLink =
      "https://docs.google.com/spreadsheets/d/1GSXklTF_v_h918zluRpxXJfbggM7j_fjRbYDSWvlhyw/edit?usp=sharing";

    private static readonly string OrderFoodDocLink =
      "https://docs.google.com/spreadsheets/d/1cr-2gQjoW9ILCzwHLC6hecKbSiDHrMofgwg-hgjyMW8/edit#gid=269517142";

    private static string FoodOrderDoc = "1cr-2gQjoW9ILCzwHLC6hecKbSiDHrMofgwg-hgjyMW8"; // PROD
    //private static string FoodOrderDoc = "1Or2ivpmF_MoounfN_k4ZeX78dgeKfh74wOzAvVbg6lY";

    public Form1()
    {
      InitializeComponent();
      Init();
    }

    private void Init()
    {
      daysListBox.DataSource = new string[] { "Mo", "Tu", "We" };
      if (!String.IsNullOrEmpty(Properties.Settings.Default.Name))
        nameTbox.Text = Properties.Settings.Default.Name;
    }

    private static void SetFood(SheetsService service, int dayIndex, int nameCellIndex, string foodCompany, string food,
      int foodPrice)
    {
      var day = GetColumnNameByDay(dayIndex);
      var cell = $"'{foodCompany}'!{day}{nameCellIndex}:{(char)(day + 1)}{nameCellIndex}";
      var body = new ValueRange { Values = new List<IList<object>>() { new List<object>() { food, foodPrice } } };

      var updateRequest = service.Spreadsheets.Values.Update(body, FoodOrderDoc, cell);
      updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;

      var updateResponse = updateRequest.Execute();
      if (updateResponse.UpdatedCells > 0)
        Console.WriteLine($"Success: {(DayOfWeek)dayIndex}- {food} ({foodPrice})");
    }

    private static int GetNameCellIndex(string foodCompany, SheetsService service, string name)
    {
      var namesRange = $"\'{foodCompany}'!A{NamesStartIndex}:A700";
      var namesRequest = service.Spreadsheets.Values.Get(FoodOrderDoc, namesRange);
      var response = namesRequest.Execute();
      var values = response.Values;

      int nameCellIndex = -1;

      if (values != null && values.Count > 0)
      {
        for (int index = 0; index < values.Count; index++)
        {
          var row = values[index];
          if (name.Equals(row[0].ToString(), StringComparison.OrdinalIgnoreCase))
          {
            nameCellIndex = NamesStartIndex + index;
            Console.WriteLine($"A{nameCellIndex}");
            break;
          }
        }
      }
      else
      {
        Console.WriteLine("Unable to find name.");
      }
      return nameCellIndex;
    }

    private static IEnumerable<Food> GetFood(SheetsService service, string name)
    {
      var foodRange = $"\'{name}'!A2:E700";
      var foodRequest = service.Spreadsheets.Values.Get(PredefinedFoodDoc, foodRange);
      var response = foodRequest.Execute();
      var values = response.Values;

      if (values == null || values.Count <= 0) yield break;

      foreach (var row in values)
      {
        var food = new Food
        {
          Company = row[0].ToString(),
          Name = row[1].ToString()
        };

        int chance;
        food.Chance = row.Count > 4 && int.TryParse(row[4].ToString(), out chance) ? chance : 10;
        int type;
        food.Type = row.Count > 3 && int.TryParse(row[3].ToString(), out type) ? (FoodType)type : FoodType.First;
        int price;
        if (row.Count > 2 && int.TryParse(row[2].ToString(), out price))
          food.Price = price;
        else
          throw new InvalidDataException("Price is empty");

        yield return
          food;
      }
    }

    private static SheetsService InitService()
    {
      UserCredential credential;

      using (var stream = new FileStream("client_id.json", FileMode.Open, FileAccess.Read))
      {
        string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
          GoogleClientSecrets.Load(stream).Secrets,
          Scopes,
          "user",
          CancellationToken.None,
          new FileDataStore(credPath, true)).Result;
        Console.WriteLine("Credential file saved to: " + credPath);
      }

      // Create Google Sheets API service.
      var service = new SheetsService(new BaseClientService.Initializer()
      {
        HttpClientInitializer = credential,
        ApplicationName = ApplicationName,
      });
      return service;
    }

    private static char GetColumnNameByDay(int dayOfWeek)
    {
      switch (dayOfWeek)
      {
        case 1:
          return 'B';
        case 2:
          return 'D';
        case 3:
          return 'F';
        case 4:
          return 'H';
        case 5:
          return 'J';
        default:
          throw new InvalidDataException();
      }
    }

    private void GetRandomFoodBtn_Click(object sender, EventArgs e)
    {
      try
      {
        var service = InitService();

        _name = Properties.Settings.Default.Name;
        if (string.IsNullOrEmpty(_name)) throw new Exception("Empty name");

        var todayDayIndex = 1; //(int)DateTime.Now.DayOfWeek; //0 = вс
        var days = _maxOrderDay - todayDayIndex;

        var rnd = new Random();

        var allFoods = GetFood(service, _name).Where(f => f.Type == FoodType.First).ToList();
        if (!allFoods.Any()) throw new InvalidDataException("No food");
        var foods = new List<Food>();
        foreach (var f in allFoods)
        {
          for (int i = 0; i < f.Chance; i++)
          {
            foods.Add(f);
          }
        }

        while (foods.Count < days)
        {
          foods.AddRange(foods);
        }

        _foods = foods = foods.OrderBy(x => rnd.Next()).Take(days).ToList();

        foodDataGridView.DataSource = foods;
        SetInDocButton.Enabled = true;
      }
      catch (Exception exc)
      {
        var mb = MessageBox.Show(this, exc.Message ?? "Error");
      }
    }

    private void SetInDocButton_Click(object sender, EventArgs e)
    {
      if (_foods == null) return;
      this.Cursor = Cursors.WaitCursor;
      var t = new TaskFactory().StartNew(() =>
      {
        var todayDayIndex = 1; //(int)DateTime.Now.DayOfWeek; //0 = вс
        var service = InitService();
        for (int dayIndex = todayDayIndex; dayIndex < _maxOrderDay; dayIndex++)
        {
          var f = _foods[dayIndex - 1];
          var nameCellIndex = GetNameCellIndex(f.Company, service, _name);

          SetFood(service, dayIndex, nameCellIndex, f.Company, f.Name, f.Price);
        }
      });

      t.ContinueWith(task =>
      {
        this.Cursor = Cursors.Default;
      });

      t.ContinueWith(state =>
      {
        var mb = MessageBox.Show(this, state.Exception?.Message ?? "Error");
      }, TaskContinuationOptions.OnlyOnFaulted);
    }

    private void ClearInDocButton_Click(object sender, EventArgs e)
    {
      _name = Properties.Settings.Default.Name;
      if (string.IsNullOrEmpty(_name))
      {
        MessageBox.Show(this, "Empty Name");
        return;
      }

      var d = MessageBox.Show("Do you really want to clear doc?", "Important Question", MessageBoxButtons.YesNo);
      if (d == DialogResult.No) return;

      this.Cursor = Cursors.WaitCursor;
      var t = new TaskFactory().StartNew(() =>
      {
        var service = InitService();
        var companies = GetFood(service, _name).Select(f => f.Company).Distinct();
        var todayDayIndex = 1; //(int)DateTime.Now.DayOfWeek; //0 = вс
        Parallel.ForEach(companies, company =>
        {
          Parallel.For(todayDayIndex, _maxOrderDay, i =>
          {
            var nameCellIndex = GetNameCellIndex(company, service, _name);

            SetFood(service, i, nameCellIndex, company, "", 0);
          });
        });
      }).ContinueWith(task =>
      {
        this.Cursor = Cursors.Default;
      });
    }

    private void lnkPredefined_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      System.Diagnostics.Process.Start(PredefinedFoodDocEditLink);
    }

    private void orderFoodDocLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      System.Diagnostics.Process.Start(OrderFoodDocLink);
    }

    private void nameTbox_TextChanged(object sender, EventArgs e)
    {
      Properties.Settings.Default.Name = nameTbox.Text;
    }
  }
}
