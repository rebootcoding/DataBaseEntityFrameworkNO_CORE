using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Net.Http.Headers;
using DataBaseEntityFrameworkNO_CORE;

namespace DataBaseEntityFrameworkNO_CORE
{
    public partial class Form1 : Form
    {
        private AcademyNetEntities1 cxt;

        public Form1()
        {
            InitializeComponent();
            cxt = new AcademyNetEntities1();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.DataSource = GetNameTables();

        }

        private List<string> GetNameTables()
        {
            List<string> result = new List<string>();
            var metadata = ((IObjectContextAdapter)cxt).ObjectContext.MetadataWorkspace;    //info sul db

            //prende le entità indicate come table e le mette in table
            var tables = metadata.GetItemCollection(DataSpace.SSpace)
                .GetItems<EntityContainer>()
                .Single()
                .BaseEntitySets
                .OfType<EntitySet>()
                .Where(s => !s.MetadataProperties.Contains("Type")
                || s.MetadataProperties["Type"].ToString() == "Tables");

            foreach (var table in tables)
            {
                var tableName = table.MetadataProperties.Contains("Table")
                   && table.MetadataProperties["Table"].Value != null
                    ? table.MetadataProperties["Table"].Value.ToString()
                    : table.Name;

                var tableSchema = table.MetadataProperties["Schema"].Value.ToString();

                result.Add(tableName);

            }
            return result;
        }

        //private List<EntitySet> GetDataTable()
        //{
        //    List<EntitySet> dtList = new List<EntitySet>();
        //    using (cxt)
        //    {
        //        var metadata = ((IObjectContextAdapter)cxt).ObjectContext.MetadataWorkspace;

        //        var tables = metadata.GetItemCollection(DataSpace.SSpace)
        //                       .GetItems<EntityContainer>()
        //                       .Single()
        //                       .BaseEntitySets
        //                       .OfType<EntitySet>()
        //                       .Where(s => !s.MetadataProperties.Contains("Type")
        //                         || s.MetadataProperties["Type"].ToString() == "Tables");
        //        foreach (var table in tables)
        //        {
        //            dtList.Add(table);
        //        }
        //    }


        //    return dtList;
        //}
        //private List<object> GetObject()
        //{
        //    List<object> result = new List<object>();
        //    var metadata = ((IObjectContextAdapter)cxt).ObjectContext.MetadataWorkspace;    //info sul db

        //    //prende le entità indicate come table e le mette in table
        //    var tables = metadata.GetItemCollection(DataSpace.SSpace)
        //        .GetItems<EntityContainer>()
        //        .Single()
        //        .BaseEntitySets
        //        .OfType<EntitySet>()
        //        .Where(s => !s.MetadataProperties.Contains("Type")
        //        || s.MetadataProperties["Type"].ToString() == "Tables");

        //    foreach (var table in tables)
        //    {
        //        var tableName = table.MetadataProperties.Contains("Table")
        //           && table.MetadataProperties["Table"].Value != null
        //            ? table.MetadataProperties["Table"].Value
        //            : table.Name;

        //        result.Add(tableName);

        //    }
        //    return result;
        //}


        //public object GetSet(AcademyNetEntities1 nome, string nomeTable)
        //{
        //    switch (nomeTable)
        //    {
        //        case "staff":
        //            {
        //                return nome.staffs;
        //            }
        //        case "brands":
        //            {
        //                return nome.brands;
        //            }
        //        case "categories":
        //            {
        //                return nome.categories;
        //            }
        //        case "products":
        //            {
        //                return nome.products;
        //            }
        //        case "stocks":
        //            {
        //                return nome.stocks;
        //            }
        //        case "customers":
        //            {
        //                return nome.customers;
        //            }
        //        case "order_items":
        //            {
        //                return nome.order_items;
        //            }
        //        case "orders":
        //            {
        //                return nome.orders;
        //            }
        //        case "staffs":
        //            {
        //                return nome.staffs;
        //            }
        //        case "stores":
        //            {
        //                return nome.stores;
        //            }
        //        default:
        //            {
        //                return nome.brands;
        //            }
        //    }

        //}

        //private List<EntitySet> GetEntity()
        //{
        //    List<EntitySet> result = new List<EntitySet>();

        //    using (cxt)
        //    {
        //        var metadata = ((IObjectContextAdapter)cxt).ObjectContext.MetadataWorkspace;

        //        var tables = metadata.GetItemCollection(DataSpace.SSpace)
        //                       .GetItems<EntityContainer>()
        //                       .Single()
        //                       .BaseEntitySets
        //                       .OfType<EntitySet>()
        //                       .Where(s => !s.MetadataProperties.Contains("Type")
        //                         || s.MetadataProperties["Type"].ToString() == "Tables");

        //        foreach (var table in tables)
        //        {
        //            result.Add(table);

        //        }
        //        return result;
        //    }
        //}

        //public List<string> GetTables()
        //{
        //    List<string> result = new List<string>();

        //    using (cxt)
        //    {
        //        var metadata = ((IObjectContextAdapter)cxt).ObjectContext.MetadataWorkspace;

        //        var tables = metadata.GetItemCollection(DataSpace.SSpace)
        //                       .GetItems<EntityContainer>()
        //                       .Single()
        //                       .BaseEntitySets
        //                       .OfType<EntitySet>()
        //                       .Where(s => !s.MetadataProperties.Contains("Type")
        //                         || s.MetadataProperties["Type"].ToString() == "Tables");

        //        foreach (var table in tables)
        //        {
        //            var tableName = table.MetadataProperties.Contains("Table")
        //                           && table.MetadataProperties["Table"].Value != null
        //                         ? table.MetadataProperties["Table"].Value.ToString()
        //                         : table.Name;

        //            var tableSchema = table.MetadataProperties["Schema"].Value.ToString();
        //            if (tableName == "sysdiagrams")
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                result.Add(tableName);
        //            }
        //        }
        //        return result;
        //    }
        //}

        private void btn_Load_Click(object sender, EventArgs e)
        {
            var selezione = comboBox1.SelectedItem;
            switch (selezione)
            {
                case "staffs":

                    dataGridView1.DataSource = cxt.staffs.ToList();
                    break;
                case "brands":

                    dataGridView1.DataSource = cxt.brands.ToList();
                    break;

                case "categories":

                    dataGridView1.DataSource = cxt.categories.ToList();
                    break;

                case "products":

                    dataGridView1.DataSource = cxt.products.ToList();
                    break;

                case "stocks":

                    dataGridView1.DataSource = cxt.stocks.ToList();
                    break;

                case "customers":

                    dataGridView1.DataSource = cxt.customers.ToList();
                    break;

                case "order_items":

                    dataGridView1.DataSource = cxt.order_items.ToList();
                    break;

                case "orders":

                    dataGridView1.DataSource = cxt.orders.ToList();
                    break;

                default:

                    dataGridView1.DataSource = cxt.stores.ToList();
                    break;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cxt.SaveChanges();
            MessageBox.Show("Dati aggiornati!");
        }
    }
}
