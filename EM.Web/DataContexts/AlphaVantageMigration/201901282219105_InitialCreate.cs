namespace EM.Web.DataContexts.AlphaVantageMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MetaDatas",
                c => new
                    {
                        Guid = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        MetaInfo_The1Information = c.String(),
                        MetaInfo_The2Symbol = c.String(),
                        MetaInfo_The3LastRefreshed = c.DateTimeOffset(nullable: false, precision: 7),
                        MetaInfo_The4Interval = c.String(),
                        MetaInfo_The5OutputSize = c.String(),
                        MetaInfo_The6TimeZone = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MetaDatas");
        }
    }
}
