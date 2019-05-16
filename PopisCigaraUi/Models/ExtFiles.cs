using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PopisCigaraUi
{
   public class ExtFiles
    {

       string thePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string dataFileXls = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "PopisCigara" + Path.DirectorySeparatorChar + "popis.xls";
      public string cigiTempFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "PopisCigara" + Path.DirectorySeparatorChar + "CigiTemp.csv";
        public void createDir()
        {
            string theDir = thePath + Path.DirectorySeparatorChar + "PopisCigara";
            string thePopisiDir = theDir + Path.DirectorySeparatorChar + "Popisi";

            bool dirExists = Directory.Exists(theDir);
            bool dirPopisi = Directory.Exists(thePopisiDir);

            if (!dirExists) { Directory.CreateDirectory(theDir); }
            if (!dirPopisi) { Directory.CreateDirectory(thePopisiDir); }


        }



        public void addData(List<Cigi> cigare)
        {


            List<Cigi> filterLIst = new List<Cigi>();

            if (File.Exists(dataFileXls))
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0; data source={dataFileXls}; Extended Properties=Excel 8.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM[popis$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "TestTable");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                MyConnection.Close();


                foreach (DataTable table in DtSet.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        filterLIst.Add(new Cigi(Convert.ToInt64(row["artid"]), row["naziv"].ToString(), Convert.ToInt32(row["kol"]), Convert.ToInt32(row["cena"]), row["nazgrupa"].ToString()));
                    }
                }


                var q =
                    from art in filterLIst
                    where art.nazGrupa.Contains("CIGARETE")
                    select art;

                foreach (var item in q)
                {
                    cigare.Add(new Cigi(item.Barcode,item.Name,item.Kolicina,item.Cena));
                }

            }



            #region stari metod
            //if (File.Exists(dataFileXls))
            //{
            //    string[] fileContent = File.ReadAllLines(dataFileXls);
            //    foreach (string s in fileContent)
            //    {
            //        string[] row;
            //        if (s.Contains(';'))
            //        {
            //            row = s.Split(';');

            //            for (int i = 0; i < row.Length; i++)
            //            {
            //                row[2] = "0";
            //                cigare.Add(new Cigi(long.Parse(row[0]), row[1], int.Parse(row[2]), int.Parse(row[3])));
            //            }
            //        }
            //        else if (s.Contains(','))
            //        {
            //            row = s.Split(',');

            //            for (int i = 0; i < row.Length; i++)
            //            {
            //                row[2] = "0";
            //                cigare.Add(new Cigi(long.Parse(row[0]), row[1], int.Parse(row[2]), int.Parse(row[3])));
            //            }
            //        }
                  
            //    }
            //}

            #endregion
        }
        public void saveTempList(ListView listManjak)
        {
            if (!File.Exists(cigiTempFile))
            {
                using (File.Create(cigiTempFile)) { } ;
            }
            if (File.Exists(cigiTempFile))
            {
                using (StreamWriter sw = new StreamWriter(cigiTempFile))
                {
                    foreach (Cigi c in listManjak.Items)
                    {
                        sw.WriteLine(c.Barcode.ToString() + ',' + c.Name + ',' + c.Kolicina + ',' + c.Cena);
                    }
                }
            }


        }

        public void loadData(ListView list)
        {
            if (File.Exists(cigiTempFile))
            {
                string[] fileContent = File.ReadAllLines(cigiTempFile);
                string[] row;
                foreach (string s in fileContent)
                {
                    row = s.Split(',');                   
                    list.Items.Add(new Cigi(long.Parse(row[0]), row[1], int.Parse(row[2]), int.Parse(row[3])));
                   
                }
            }
        }


        public void saveList(ListView listV)
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy");           
            string theDir = thePath + Path.DirectorySeparatorChar + "PopisCigara";
            string popisFile = theDir + Path.DirectorySeparatorChar + "Popisi" + Path.DirectorySeparatorChar + $"{date}.csv";
           
          
          
            if (!File.Exists(popisFile))
            {
                using (File.Create(popisFile)) { }
                if (File.Exists(popisFile))
                {
                    using (StreamWriter sw = new StreamWriter(popisFile))
                    {
                        foreach (Cigi c in listV.Items)
                        {
                            sw.WriteLine(c.Barcode.ToString() + ',' + c.Name + ',' + c.Kolicina + ',' + c.Cena + ',' + date + ',' + Cigi.UkupanManjak.ToString());
                        }
                    }
                }




            }
              
           
        }

    }
}
