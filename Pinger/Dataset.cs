using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Pinger
{
    public class Dataset
    {
        public static readonly string FileName = Environment.CurrentDirectory + @"\pings.csv";

        public static IEnumerable<Record> Read()
        {
            using (var reader = new StreamReader(FileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Record>();
            }
        }

        public static void Write(Record record)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var stream = File.Open(FileName, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecord(record);
            }
        }

        public static void Init()
        {
            if (File.Exists(FileName))
                return;

            using (var writer = new StreamWriter(FileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<Record>();
                csv.NextRecord();
            }
        }
    }
}
