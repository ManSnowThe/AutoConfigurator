using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.IO;

namespace conf
{
    class Info
    {
        Series series = new Series();
        Model model = new Model();
        Exterior exterior = new Exterior();
        Interior interior = new Interior();
        Options options = new Options();

        // Конвертация byte[] в Bitmap, который используется для изображения.
        public static Bitmap ByteToImage(byte[] blob)
        {

            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        // Загрузка изображения из базы данных.
        byte[] images;

        public byte[] ImageSeries()
        {
            images = null;
            foreach (DataRow row in series.GetSeries().Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState == tablename)
                {
                    images = (byte[])row[2];
                }
            }
            return images;
        }

        // Получает изображение модели
        public byte[] ImageModel()
        {
            images = null;
            foreach (DataRow row in model.GetModel(series.SerChoice()).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState2 == tablename)
                {
                    images = (byte[])row[2];
                }
            }
            return images;
        }

        public string Spec { get; set; }

        // Получает спецификацию модели
        public string SpecModel()
        {
            foreach (DataRow row in model.GetModel(series.SerChoice()).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState2 == tablename)
                {
                    Spec = (string)row[3];
                }
            }
            return Spec;
        }

        public double Price { get; set; }

        // Получает цену модели
        public double PriceModel()
        {
            foreach (DataRow row in model.GetModel(series.SerChoice()).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState2 == tablename)
                {
                    Price = (double)row[4];
                }
            }
            return Price;
        }

        public string ModN { get; set; }

        // Получает имя модели
        public string NameModel()
        {
            foreach (DataRow row in model.GetModel(series.SerChoice()).Rows)
            {
                string tablename4 = (string)row[1];
                if (Form2.selectedState2 == tablename4)
                {
                    ModN = (string)row[1];
                }
            }
            return ModN;
        }

        public string SerN { get; set; }

        //Получает имя серии
        public string NameSeries()
        {
            foreach (DataRow row in series.GetSeries().Rows)
            {
                string tablename4 = (string)row[1];
                if (Form2.selectedState == tablename4)
                {
                    SerN = (string)row[1];
                }
            }
            return SerN;
        }

        // Вставка картинок в экстерьер
        public byte[] ImageExterior(decimal n)
        {
            images = null;
            foreach (DataRow row in exterior.GetExteriorRel(model.ModChoice(), n).Rows)
            {
                if (n == 1)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState4 == tablename)
                    {
                        images = (byte[])row[2];
                    }
                }
                else if (n == 2)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState5 == tablename)
                    {
                        images = (byte[])row[2];
                    }
                }
            }
            return images;
        }

        public string SpecExt { get; set; }

        // Получает спецификацию экстерьера
        public string SpecExter(decimal n)
        {
            foreach (DataRow row in exterior.GetExteriorRel(model.ModChoice(), n).Rows)
            {
                if (n == 1)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState4 == tablename)
                    {
                        SpecExt = (string)row[3];
                    }
                }
                else if (n == 2)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState5 == tablename)
                    {
                        SpecExt = (string)row[3];
                    }
                }
            }
            return SpecExt;
        }

        public double PriceExt { get; set; }

        // Получает цену экстерьера
        public double PriceExter(decimal n)
        {
            foreach (DataRow row in exterior.GetExteriorRel(model.ModChoice(), n).Rows)
            {
                if (n == 1)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState4 == tablename)
                    {
                        PriceExt = (double)row[4];
                    }
                }
                else if (n == 2)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState5 == tablename)
                    {
                        PriceExt = (double)row[4];
                    }
                }
            }
            return PriceExt;
        }

        public string ExtN { get; set; }

        // Получает имя экстерьера
        public string NameExter(decimal n)
        {
            foreach (DataRow row in exterior.GetExteriorRel(model.ModChoice(), n).Rows)
            {
                if (n == 1)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState4 == tablename)
                    {
                        ExtN = (string)row[1];
                    }
                }
                else if (n == 2)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState5 == tablename)
                    {
                        ExtN = (string)row[1];
                    }
                }
            }
            return ExtN;
        }

        // Получает изображение интерьера
        public byte[] ImageInterior(decimal n)
        {
            images = null;
            foreach (DataRow row in interior.GetInteriorRel(model.ModChoice(), n).Rows)
            {
                if (n == 1)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState6 == tablename)
                    {
                        images = (byte[])row[2];
                    }
                }
                else if (n == 2)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState7 == tablename)
                    {
                        images = (byte[])row[2];
                    }
                }
            }
            return images;
        }

        public string SpecInt { get; set; }

        // Получает спецификацию интерьера
        public string SpecInter(decimal n)
        {
            foreach (DataRow row in interior.GetInteriorRel(model.ModChoice(), n).Rows)
            {
                if (n == 1)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState6 == tablename)
                    {
                        SpecInt = (string)row[3];
                    }
                }
                else if (n == 2)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState7 == tablename)
                    {
                        SpecInt = (string)row[3];
                    }
                }
            }
            return SpecInt;
        }

        public double PriceInt { get; set; }

        // Получает цену интерьера
        public double PriceInter(decimal n)
        {
            foreach (DataRow row in interior.GetInteriorRel(model.ModChoice(), n).Rows)
            {
                if (n == 1)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState6 == tablename)
                    {
                        PriceInt = (double)row[4];
                    }
                }
                else if (n == 2)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState7 == tablename)
                    {
                        PriceInt = (double)row[4];
                    }
                }
            }
            return PriceInt;
        }

        public string IntN { get; set; }

        // Получает имя интерьера
        public string NameInter(decimal n)
        {
            foreach (DataRow row in interior.GetInteriorRel(model.ModChoice(), n).Rows)
            {
                if (n == 1)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState6 == tablename)
                    {
                        IntN = (string)row[1];
                    }
                }
                else if (n == 2)
                {
                    string tablename = (string)row[1];
                    if (Form2.selectedState7 == tablename)
                    {
                        IntN = (string)row[1];
                    }
                }
            }
            return IntN;
        }

        // Получает изображение опции
        public byte[] ImageOption()
        {
            images = null;
            foreach (DataRow row in options.GetOpt2(model.ModChoice()).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState9 == tablename)
                {
                    images = (byte[])row[2];
                }
            }
            return images;
        }

        public string SpecOpt { get; set; }

        // Получает спецификацию опции
        public string SpecOption()
        {
            foreach (DataRow row in options.GetOpt2(model.ModChoice()).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState9 == tablename)
                {
                    SpecOpt = (string)row[3];
                }
            }
            return SpecOpt;
        }

        public double PriceOpt { get; set; }

        // Получает цену опции
        public double PriceOption()
        {
            foreach (DataRow row in options.GetOpt2(model.ModChoice()).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState9 == tablename)
                {
                    PriceOpt = (double)row[4];
                }
            }
            return PriceOpt;
        }

        public string OptN { get; set; }

        // Получает имя опции
        public string NameOption()
        {
            foreach (DataRow row in options.GetOpt2(model.ModChoice()).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState9 == tablename)
                {
                    OptN = (string)row[1];
                }
            }
            return OptN;
        }
    }
}
