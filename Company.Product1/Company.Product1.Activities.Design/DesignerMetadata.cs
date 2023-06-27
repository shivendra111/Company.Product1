using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using Company.Product1.Activities.Design.Designers;
using Company.Product1.Activities.Design.Properties;

namespace Company.Product1.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(Addition), categoryAttribute);
            builder.AddCustomAttributes(typeof(Addition), new DesignerAttribute(typeof(AdditionDesigner)));
            builder.AddCustomAttributes(typeof(Addition), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
