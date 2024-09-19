using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using Kendo.Mvc;
using Telerik.SvgIcons;

namespace CleanArchitecture.Web
{
    public class DataSourceRequestState: DataSourceRequest
    {
        private string _filter = "";
        private string _sort = "";
        private string _group = "";
        private string _aggregate = "";

        public int Size
        {
            get => PageSize;
            set => PageSize = value;
        }

        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                // sourced from: Kendo.Mvc.UI.DataSourceRequestModelBinder
                Filters = FilterDescriptorFactory.Create(value);
            }
        }

        public string Sort
        {
            get => _sort;
            set
            {
                _sort = value;
                // sourced from: Kendo.Mvc.UI.DataSourceRequestModelBinder
                Sorts = DataSourceDescriptorSerializer.Deserialize<SortDescriptor>(value);
            }
        }

        public string Group
        {
            get => _group;
            set
            {
                _group = value;
                // sourced from: Kendo.Mvc.UI.DataSourceRequestModelBinder
                Groups = DataSourceDescriptorSerializer.Deserialize<GroupDescriptor>(value);
            }
        }

        public string Aggregate
        {
            get => _aggregate;
            set
            {
                _aggregate = value;
                // sourced from: Kendo.Mvc.UI.DataSourceRequestModelBinder
                Aggregates = DataSourceDescriptorSerializer.Deserialize<AggregateDescriptor>(value);
            }
        }
    }
}
