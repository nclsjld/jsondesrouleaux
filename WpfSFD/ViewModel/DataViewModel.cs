using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfSFD.Views;

namespace WpfSFD.ViewModel
{
    public class DataViewModel
    {
        private DataInsertView dataInsertView;

        public DataViewModel()
        {
            dataInsertView = new DataInsertView();
            dataInsertView.DataContext = this;
            //insertBtn

            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = dataInsertView;
            dataInsertView.insertBtn.Click += insertBtn_OnClick;
        }

        private void insertBtn_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
