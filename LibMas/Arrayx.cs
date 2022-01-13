using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMas
{
    public class Arrayx
    {

        Random _random = new Random();
        int[] array;
        public int Length => array.Length;

        public void Initialize(int min = -10, int max = 10)
        {
            for (int i = 0; i < Length; i++)
            {
                array[i] = _random.Next(min, max);
            }
        }

        public void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(Length);

                for (int i = 0; i < Length; i++)
                {
                    writer.WriteLine(array[i]);
                }
            }
        }

        public void Open(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                array = new int[int.Parse(reader.ReadLine())];

                for (int i = 0; i < Length; i++)
                {
                    array[i] = int.Parse(reader.ReadLine());
                }
            }
        }

        public Arrayx(int length)
        {
            array = new int[length];
        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < array.Length; i++)
            {
                res.Columns.Add("col" + (i + 1));
            }
            var row = res.NewRow();
            for (int i = 0; i < Length; i++)
            {
                row[i] = array[i];
            }
            res.Rows.Add(row);
            return res;
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public void Clear()
        {
            Initialize(0, 0);
        }
    }
}
