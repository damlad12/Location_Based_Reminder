

using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net;
using Remind_Location.Data;
using Remind_Location.Entity;
using System.Data;

namespace Remind_Location
{
    public partial class Form1 : Form
    {
        public string username;
        public Form1(string _username)
        {
            InitializeComponent();
            username = _username;
            this.add_saved_locations(username);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var location = new Location();
            location.Latitude = (decimal)Convert.ToDouble(txtLatitude.Text);
            location.Longitude = (decimal)Convert.ToDouble(txtLongitude.Text);
            var repo = new LocationRepository();
            bool isSuccess = repo.Create(location, username);
            if (isSuccess)
            {
                MessageBox.Show("Success");
                add_new_location(txtLatitude.Text, txtLongitude.Text);
            }
            else
            {
                MessageBox.Show("fail");
            }
        }

        private void add_new_location(string _lat, string _lng)
        {
            string[] newLoc = { _lat, _lng };
            ListViewItem item = new ListViewItem(newLoc);
            listView1.Items.Add(item);
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            listView1.SelectedItems[0].Text = txtLatitude.Text;
            listView1.SelectedItems[0].SubItems[1].Text = txtLongitude.Text;
        }

        public void add_saved_locations(string username)
        {
             listView1.View = View.Details;
             listView1.Columns.Add("Latitude", -2, HorizontalAlignment.Left);
             listView1.Columns.Add("Longitude", -2, HorizontalAlignment.Left);

            var locations = new List<Location>();
            LocationRepository locrepo = new LocationRepository();
            locrepo.ReturnLocations(locations, username);

            for (int i = 0; i < locations.Count(); i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = locations[i].Latitude.ToString();
                item.SubItems.Add(locations[i].Longitude.ToString());
                listView1.Items.Add(item);
            }

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var lat = listView1.SelectedItems[0].Text;
                var lng = listView1.SelectedItems[0].SubItems[1].Text;
                txtLatitude.Text = lat;
                txtLongitude.Text = lng;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }


    }
}