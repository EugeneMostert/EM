namespace EM.Web.DataContexts.AlphaVantageMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MetaDatas");
            AddColumn("dbo.MetaDatas", "MetaInfo_Information", c => c.String());
            AddColumn("dbo.MetaDatas", "MetaInfo_Symbol", c => c.String());
            AddColumn("dbo.MetaDatas", "MetaInfo_LastRefreshed", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.MetaDatas", "MetaInfo_Interval", c => c.String());
            AddColumn("dbo.MetaDatas", "MetaInfo_OutputSize", c => c.String());
            AddColumn("dbo.MetaDatas", "MetaInfo_TimeZone", c => c.String());
            AlterColumn("dbo.MetaDatas", "Guid", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.MetaDatas", "Guid");
            DropColumn("dbo.MetaDatas", "MetaInfo_The1Information");
            DropColumn("dbo.MetaDatas", "MetaInfo_The2Symbol");
            DropColumn("dbo.MetaDatas", "MetaInfo_The3LastRefreshed");
            DropColumn("dbo.MetaDatas", "MetaInfo_The4Interval");
            DropColumn("dbo.MetaDatas", "MetaInfo_The5OutputSize");
            DropColumn("dbo.MetaDatas", "MetaInfo_The6TimeZone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MetaDatas", "MetaInfo_The6TimeZone", c => c.String());
            AddColumn("dbo.MetaDatas", "MetaInfo_The5OutputSize", c => c.String());
            AddColumn("dbo.MetaDatas", "MetaInfo_The4Interval", c => c.String());
            AddColumn("dbo.MetaDatas", "MetaInfo_The3LastRefreshed", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.MetaDatas", "MetaInfo_The2Symbol", c => c.String());
            AddColumn("dbo.MetaDatas", "MetaInfo_The1Information", c => c.String());
            DropPrimaryKey("dbo.MetaDatas");
            AlterColumn("dbo.MetaDatas", "Guid", c => c.Guid(nullable: false, identity: true));
            DropColumn("dbo.MetaDatas", "MetaInfo_TimeZone");
            DropColumn("dbo.MetaDatas", "MetaInfo_OutputSize");
            DropColumn("dbo.MetaDatas", "MetaInfo_Interval");
            DropColumn("dbo.MetaDatas", "MetaInfo_LastRefreshed");
            DropColumn("dbo.MetaDatas", "MetaInfo_Symbol");
            DropColumn("dbo.MetaDatas", "MetaInfo_Information");
            AddPrimaryKey("dbo.MetaDatas", "Guid");
        }
    }
}
