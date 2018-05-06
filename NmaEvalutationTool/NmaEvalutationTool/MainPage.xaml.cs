using System.Net.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NmaEvalutationTool
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            QuestionGUI.Items.Add("1");
            QuestionGUI.Items.Add("2");
            QuestionGUI.Items.Add("3");
            QuestionGUI.Items.Add("4");
            QuestionGUI.Items.Add("5");
            QuestionGUI.Items.Add("6");

            QuestionCode.Items.Add("1");
            QuestionCode.Items.Add("2");
            QuestionCode.Items.Add("3");
            QuestionCode.Items.Add("4");
            QuestionCode.Items.Add("5");
            QuestionCode.Items.Add("6");

            QuestionResearch.Items.Add("1");
            QuestionResearch.Items.Add("2");
            QuestionResearch.Items.Add("3");
            QuestionResearch.Items.Add("4");
            QuestionResearch.Items.Add("5");
            QuestionResearch.Items.Add("6");

            QuestionPresentation.Items.Add("1");
            QuestionPresentation.Items.Add("2");
            QuestionPresentation.Items.Add("3");
            QuestionPresentation.Items.Add("4");
            QuestionPresentation.Items.Add("5");
            QuestionPresentation.Items.Add("6");

            QuestionOverall.Items.Add("1");
            QuestionOverall.Items.Add("2");
            QuestionOverall.Items.Add("3");
            QuestionOverall.Items.Add("4");
            QuestionOverall.Items.Add("5");
            QuestionOverall.Items.Add("6");

            btnFinish.Clicked += BtnFinish_Clicked;


        }

        private async void BtnFinish_Clicked(object sender, EventArgs e)
        {

            string url = "http://evaluation.cursusweb.be/api/evaluation"; 

            string userName = usernameEntry.Text;
            string groupName = group.Text;
            int score1 = Convert.ToInt32(QuestionGUI.Items[QuestionGUI.SelectedIndex]);
            int score2 = Convert.ToInt32(QuestionCode.Items[QuestionCode.SelectedIndex]);
            int score3 = Convert.ToInt32(QuestionResearch.Items[QuestionResearch.SelectedIndex]);
            int score4 = Convert.ToInt32(QuestionPresentation.Items[QuestionPresentation.SelectedIndex]);
            int score5 = Convert.ToInt32(QuestionOverall.Items[QuestionOverall.SelectedIndex]);
            string remarks = Remarks.Text;

            var client = new HttpClient();
            

            JsonObject jsonObject = new JsonObject(userName, groupName, score1, score2, score3, score4, score5, remarks);
            string jsonObjectString = JsonConvert.SerializeObject(jsonObject);
            var content = new StringContent(jsonObjectString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            var responseSting = await response.Content.ReadAsStringAsync();




            await Navigation.PushModalAsync(new SuccesScreen());
        }
    }
}
