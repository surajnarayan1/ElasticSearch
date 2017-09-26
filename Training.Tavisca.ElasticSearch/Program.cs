using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace Training.Tavisca.ElasticSearch
{
    class Program
    {
        public static Uri node;
        public static ConnectionSettings settings;
        public static ElasticClient client;

        static void Main(string[] args)
        {
            node = new Uri("http://172.16.14.148:9200/");
            var settings = new ConnectionSettings(node);
            client = new ElasticClient(settings);
            Student student = new Student();
            student.RegistrationNumber = "101";
            student.Name = "Suraj";
            student.Batch = "2017";
            student.Branch = "XYZ";
            student.Address = "ABC";
            AddNewIndex(student);
            List<Student> list = Search("Physics");
        }
        public static void AddNewIndex(Student model)
        {
            var jsonData = new Student
            {
                RegistrationNumber = model.RegistrationNumber,
                Name = model.Name,
                Address = model.Address,
                Branch = model.Branch,
                Batch = model.Batch,
            };
            client.Index<Student>(jsonData,x=>x.Index("blog").Type("mydata").Id(model.RegistrationNumber).Refresh(Elasticsearch.Net.Refresh.True));

        }
        public static List<Student> Search(string word)
        {
            List<Student> list = new List<Student>();
            var response=client.Search<Student>(x=>x.Index("blueprint").Type("sylabus").Query(q=>q.Match(t => t.Field("name").Query(word))));
            foreach(var hit in response.Hits)
            {
                var student = new Student();
                student.RegistrationNumber = hit.Id.ToString();
                student.Name = hit.Source.Name.ToString();
                student.Address = hit.Source.Address.ToString();
                student.Batch = hit.Source.Batch.ToString();
                student.Branch = hit.Source.Branch.ToString();
                list.Add(student);
            }
            return list;
        }
      
      
    }    }

