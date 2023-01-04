using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BIDV.Models
{
    class Response_VBNB
    {
    }
    public class DocumentType
    {
        public int delete_time_period { get; set; }
        public string delete_time_unit { get; set; }
        public string documents_url { get; set; }
        public int documents_count { get; set; }
        public int id { get; set; }
        public string label { get; set; }
        public List<object> filenames { get; set; }
        public object trash_time_period { get; set; }
        public object trash_time_unit { get; set; }
        public string url { get; set; }
    }

    public class LatestVersion
    {
        public string checksum { get; set; }
        public string comment { get; set; }
        public string document_url { get; set; }
        public string download_url { get; set; }
        public string encoding { get; set; }
        public string file { get; set; }
        public string mimetype { get; set; }
        public string pages_url { get; set; }
        public int size { get; set; }
        public DateTime timestamp { get; set; }
        public string url { get; set; }
    }

    public class Result
    {
        public DateTime date_added { get; set; }
        public string description { get; set; }
        public DocumentType document_type { get; set; }
        public string document_type_change_url { get; set; }
        public int id { get; set; }
        public string label { get; set; }
        public string language { get; set; }
        public LatestVersion latest_version { get; set; }
        public string url { get; set; }
        public string uuid { get; set; }
        public int pk { get; set; }
        public string versions_url { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Result> results { get; set; }
    }
}
