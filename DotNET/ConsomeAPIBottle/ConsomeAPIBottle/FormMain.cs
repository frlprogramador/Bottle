using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsomeAPIBottle
{
    public partial class FormMain : Form
    {

        private Pen pen = new Pen(Brushes.Red, 5);


        public FormMain()
        {
            InitializeComponent();
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Arquivos JPG (*.jpg)|*.jpg|Arquivo JPEG (*.jpeg)|*.jpeg|Arquivo Bitmap (*.bmp)|*.bmp|Arquivo Gráfico Portátil (*.png)|*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                ProcessImage(open.FileName);
            }

        }

        private void ProcessImage(string filename)
        {
            try
            {
                ClearStatus();
                Bitmap bit = new Bitmap(filename);
                

                var client = new RestClient(@"http://localhost:2525");
                var request = new RestRequest("bottle", Method.Post);
                var stream = new MemoryStream();
                bit.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                var fileBytes = stream.ToArray();
                request.AddFile("image", fileBytes, "file.jpg");

                var exec = client.Execute<BottleResponse>(request);
                if (exec.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = exec.Data;
                    Graphics gr = Graphics.FromImage(bit);
                    if (result.BoxCap.Count == 4) 
                    {
                        int x = (int)result.BoxCap[0];
                        int y = (int)result.BoxCap[1];
                        int xEnd = (int)result.BoxCap[2];
                        int yEnd = (int)result.BoxCap[3];

                        gr.DrawRectangle(pen, x, y, xEnd -x +1, yEnd - y +1);



                    }
                    SetStatus(result);
                    
                }
                picCaptured.Image = bit;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearStatus()
        {
            lblAberta.BackColor = Color.Gray;
            lblFechada.BackColor = Color.Gray;
            lblNotExists.BackColor = Color.Gray;
        }
        private void SetStatus(BottleResponse response)
        {
            
            if(response.Bottle_Status == "open")
            {
                lblAberta.BackColor = Color.Green;
            }
            else if (response.Bottle_Status == "close")
            {
                lblFechada.BackColor = Color.Green;
            }
            else if(response.Bottle_Status == "notExists")
            {
                lblNotExists.BackColor = Color.Green;
            }
        }

        private void btnOpenFolter_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var files = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                foreach( var file in files )
                { 
                    lstArquivos.Items.Add( file );  
                }
            }
        }

        private void lstArquivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string file = lstArquivos.SelectedItem.ToString();

            ProcessImage(file);
        }

        private void chkAtivar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtivar.Checked)
            {
                timerAtivar.Interval = (int)(txtIntervalo.Value);
                timerAtivar.Enabled = true;
            }
            else
            {
                timerAtivar.Enabled=false;

            }

        }

        private void timerAtivar_Tick(object sender, EventArgs e)
        {
            int index = lstArquivos.SelectedIndex;
            index++;
            if(index > lstArquivos.Items.Count-1)
            {
                index = 0;
            }
            lstArquivos.SelectedIndex = index;
        }
    }
}
