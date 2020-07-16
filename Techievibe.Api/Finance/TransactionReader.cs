using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Techievibe.Api.Finance
{
    public class TransactionReader
    {
        public List<Transaction> ReadTransactionsFromFile(string absolutePath)
        {
            List<Transaction> result = new List<Transaction>();
            string value;
            using (TextReader fileReader = File.OpenText(absolutePath))
            {
                var csv = new CsvReader(fileReader, CultureInfo.CurrentCulture);

                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ",";

                csv.Configuration.RegisterClassMap<TransactionMap>();

                while (csv.Read())
                {
                    result.Add(csv.GetRecord<Transaction>());
                }
            }

            return result;
        }

    }
}
