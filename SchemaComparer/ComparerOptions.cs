using Microsoft.SqlServer.Dac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaComparer
{
    public class ComparerOptions
    {
        public DacOptions Options { get; set; }
        public List<ObjectType> ExcludeObjectTypes { get; set; }
        public List<ObjectType> DoNotDropObjectTypes { get; set; }
    }

    public class DacOptions : List<DacOption>
    {
        public List<DacOption> GetOptions()
        {
            return new List<DacOption>
            {
                new DacOption { Name = "AllowDropBlockingAssemblies", Enabled = false },
                new DacOption { Name = "AllowIncompatiblePlatform", Enabled = true },
                new DacOption { Name = "BackupDatabaseBeforeChanges", Enabled = false },
                new DacOption { Name = "BlockOnPossibleDataLoss", Enabled = false },
                new DacOption { Name = "BlockWhenDriftDetected", Enabled = false },
                new DacOption { Name = "CommentOutSetVarDeclarations", Enabled = false },
                new DacOption { Name = "CompareUsingTargetCollation", Enabled = false },
                new DacOption { Name = "CreateNewDatabase", Enabled = false },
                new DacOption { Name = "DeployDatabaseInSingleUserMode", Enabled = false },
                new DacOption { Name = "DisableAndReenableDdlTriggers", Enabled = false },
                new DacOption { Name = "DoNotAlterChangeDataCaptureObjects", Enabled = false },
                new DacOption { Name = "DoNotAlterReplicatedObjects", Enabled = false },
                new DacOption { Name = "DropConstraintsNotInSource", Enabled = false },
                new DacOption { Name = "DropDmlTriggersNotInSource", Enabled = false },
                new DacOption { Name = "DropExtendedPropertiesNotInSource", Enabled = false },
                new DacOption { Name = "DropIndexesNotInSource", Enabled = false },
                new DacOption { Name = "DropObjectsNotInSource", Enabled = false },
                new DacOption { Name = "DropPermissionsNotInSource", Enabled = false },
                new DacOption { Name = "DropRoleMembersNotInSource", Enabled = false },
                new DacOption { Name = "DropStatisticsNotInSource", Enabled = false },
                new DacOption { Name = "GenerateSmartDefaults", Enabled = false },
                new DacOption { Name = "IgnoreAnsiNulls", Enabled = false },
                new DacOption { Name = "IgnoreAuthorizer", Enabled = false },
                new DacOption { Name = "IgnoreColumnCollation", Enabled = false },
                new DacOption { Name = "IgnoreColumnOrder", Enabled = false },
                new DacOption { Name = "IgnoreComments", Enabled = false },
                new DacOption { Name = "IgnoreCryptographicProviderFilePath", Enabled = false },
                new DacOption { Name = "IgnoreDdlTriggerOrder", Enabled = false },
                new DacOption { Name = "IgnoreDdlTriggerState", Enabled = false },
                new DacOption { Name = "IgnoreDefaultSchema", Enabled = false },
                new DacOption { Name = "IgnoreDmlTriggerOrder", Enabled = false },
                new DacOption { Name = "IgnoreDmlTriggerState", Enabled = false },
                new DacOption { Name = "IgnoreExtendedProperties", Enabled = false },
                new DacOption { Name = "IgnoreFileAndLogFilePath", Enabled = false },
                new DacOption { Name = "IgnoreFilegroupPlacement", Enabled = false },
                new DacOption { Name = "IgnoreFileSize", Enabled = false },
                new DacOption { Name = "IgnoreFillFactor", Enabled = false },
                new DacOption { Name = "IgnoreFullTextCatalogFilePath", Enabled = false },
                new DacOption { Name = "IgnoreIdentitySeed", Enabled = false },
                new DacOption { Name = "IgnoreIncrement", Enabled = false },
                new DacOption { Name = "IgnoreIndexOptions", Enabled = false },
                new DacOption { Name = "IgnoreIndexPadding", Enabled = false },
                new DacOption { Name = "IgnoreKeywordCasing", Enabled = false },
                new DacOption { Name = "IgnoreLockHintsOnIndexes", Enabled = false },
                new DacOption { Name = "IgnoreLoginSids", Enabled = false },
                new DacOption { Name = "IgnoreNotForReplication", Enabled = false },
                new DacOption { Name = "IgnoreObjectPlacementOnPartitionScheme", Enabled = false },
                new DacOption { Name = "IgnorePartitionSchemes", Enabled = false },
                new DacOption { Name = "IgnorePermissions", Enabled = false },
                new DacOption { Name = "IgnoreQuotedIdentifiers", Enabled = false },
                new DacOption { Name = "IgnoreRoleMembership", Enabled = false },
                new DacOption { Name = "IgnoreRouteLifetime", Enabled = false },
                new DacOption { Name = "IgnoreSemicolonBetweenStatements", Enabled = false },
                new DacOption { Name = "IgnoreTableOptions", Enabled = false },
                new DacOption { Name = "IgnoreUserSettingsObjects", Enabled = false },
                new DacOption { Name = "IgnoreWhitespace", Enabled = false },
                new DacOption { Name = "IgnoreWithNocheckOnCheckConstraints", Enabled = false },
                new DacOption { Name = "IgnoreWithNocheckOnForeignKeys", Enabled = false },
                new DacOption { Name = "AllowUnsafeRowLevelSecurityDataMovement", Enabled = false },
                new DacOption { Name = "IncludeCompositeObjects", Enabled = false },
                new DacOption { Name = "IncludeTransactionalScripts", Enabled = false },
                new DacOption { Name = "NoAlterStatementsToChangeClrTypes", Enabled = false },
                new DacOption { Name = "PopulateFilesOnFileGroups", Enabled = false },
                new DacOption { Name = "RegisterDataTierApplication", Enabled = false },
                new DacOption { Name = "RunDeploymentPlanExecutors", Enabled = false },
                new DacOption { Name = "ScriptDatabaseCollation", Enabled = false },
                new DacOption { Name = "ScriptDatabaseCompatibility", Enabled = false },
                new DacOption { Name = "ScriptDatabaseOptions", Enabled = false },
                new DacOption { Name = "ScriptDeployStateChecks", Enabled = false },
                new DacOption { Name = "ScriptFileSize", Enabled = false },
                new DacOption { Name = "ScriptNewConstraintValidation", Enabled = false },
                new DacOption { Name = "ScriptRefreshModule", Enabled = false },
                new DacOption { Name = "TreatVerificationErrorsAsWarnings", Enabled = false },
                new DacOption { Name = "UnmodifiableObjectWarnings", Enabled = false },
                new DacOption { Name = "VerifyCollationCompatibility", Enabled = false },
                new DacOption { Name = "VerifyDeployment", Enabled = false }

            };
            
        }
        //public int CommandTimeout { get; set; }
        //public string AdditionalDeploymentContributors { get; set; }
        //public string AdditionalDeploymentContributorArguments { get; set; }
        //public dacazuredatabasespecification DatabaseSpecification { get; set; }
        //public objecttype[] DoNotDropObjectTypes { get; set; }
        //public objecttype[] ExcludeObjectTypes { get; set; }
        //public idictionary`2 SqlCommandVariableValues { get; set; }
}

    public class DacOption
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
    
//public void Test()
//    {
    
//    new DacOption { Name = "AllowDropBlockingAssemblies", Enabled = false },
//    new DacOption{ Name = "AllowIncompatiblePlatform", Enabled = false },
//    new DacOption{ Name = "BackupDatabaseBeforeChanges", Enabled = false },
//    new DacOption{ Name = "BlockOnPossibleDataLoss", Enabled = false },
//    new DacOption{ Name = "BlockWhenDriftDetected", Enabled = false },
//    new DacOption{ Name = "CommentOutSetVarDeclarations", Enabled = false },
//    new DacOption{ Name = "CompareUsingTargetCollation", Enabled = false },
//    new DacOption{ Name = "CreateNewDatabase", Enabled = false },
//    new DacOption{ Name = "DeployDatabaseInSingleUserMode", Enabled = false },
//    new DacOption{ Name = "DisableAndReenableDdlTriggers", Enabled = false },
//    new DacOption{ Name = "DoNotAlterChangeDataCaptureObjects", Enabled = false },
//    new DacOption{ Name = "DoNotAlterReplicatedObjects", Enabled = false },
//    new DacOption{ Name = "DropConstraintsNotInSource", Enabled = false },
//    new DacOption{ Name = "DropDmlTriggersNotInSource", Enabled = false },
//    new DacOption{ Name = "DropExtendedPropertiesNotInSource", Enabled = false },
//    new DacOption{ Name = "DropIndexesNotInSource", Enabled = false },
//    new DacOption{ Name = "DropObjectsNotInSource", Enabled = false },
//    new DacOption{ Name = "DropPermissionsNotInSource", Enabled = false },
//    new DacOption{ Name = "DropRoleMembersNotInSource", Enabled = false },
//    new DacOption{ Name = "DropStatisticsNotInSource", Enabled = false },
//    new DacOption{ Name = "GenerateSmartDefaults", Enabled = false },
//    new DacOption{ Name = "IgnoreAnsiNulls", Enabled = false },
//    new DacOption{ Name = "IgnoreAuthorizer", Enabled = false },
//    new DacOption{ Name = "IgnoreColumnCollation", Enabled = false },
//    new DacOption{ Name = "IgnoreColumnOrder", Enabled = false },
//    new DacOption{ Name = "IgnoreComments", Enabled = false },
//    new DacOption{ Name = "IgnoreCryptographicProviderFilePath", Enabled = false },
//    new DacOption{ Name = "IgnoreDdlTriggerOrder", Enabled = false },
//    new DacOption{ Name = "IgnoreDdlTriggerState", Enabled = false },
//    new DacOption{ Name = "IgnoreDefaultSchema", Enabled = false },
//    new DacOption{ Name = "IgnoreDmlTriggerOrder", Enabled = false },
//    new DacOption{ Name = "IgnoreDmlTriggerState", Enabled = false },
//    new DacOption{ Name = "IgnoreExtendedProperties", Enabled = false },
//    new DacOption{ Name = "IgnoreFileAndLogFilePath", Enabled = false },
//    new DacOption{ Name = "IgnoreFilegroupPlacement", Enabled = false },
//    new DacOption{ Name = "IgnoreFileSize", Enabled = false },
//    new DacOption{ Name = "IgnoreFillFactor", Enabled = false },
//    new DacOption{ Name = "IgnoreFullTextCatalogFilePath", Enabled = false },
//    new DacOption{ Name = "IgnoreIdentitySeed", Enabled = false },
//    new DacOption{ Name = "IgnoreIncrement", Enabled = false },
//    new DacOption{ Name = "IgnoreIndexOptions", Enabled = false },
//    new DacOption{ Name = "IgnoreIndexPadding", Enabled = false },
//    new DacOption{ Name = "IgnoreKeywordCasing", Enabled = false },
//    new DacOption{ Name = "IgnoreLockHintsOnIndexes", Enabled = false },
//    new DacOption{ Name = "IgnoreLoginSids", Enabled = false },
//    new DacOption{ Name = "
//    new DacOption{ Name = "IgnoreNotForReplication", Enabled = false },
//    new DacOption{ Name = "IgnoreObjectPlacementOnPartitionScheme", Enabled = false },
//    new DacOption{ Name = "IgnorePartitionSchemes", Enabled = false },
//    new DacOption{ Name = "IgnorePermissions", Enabled = false },
//    new DacOption{ Name = "IgnoreQuotedIdentifiers", Enabled = false },
//    new DacOption{ Name = "IgnoreRoleMembership", Enabled = false },
//    new DacOption{ Name = "IgnoreRouteLifetime", Enabled = false },
//    new DacOption{ Name = "IgnoreSemicolonBetweenStatements", Enabled = false },
//    new DacOption{ Name = "IgnoreTableOptions", Enabled = false },
//    new DacOption{ Name = "IgnoreUserSettingsObjects", Enabled = false },
//    new DacOption{ Name = "IgnoreWhitespace", Enabled = false },
//    new DacOption{ Name = "IgnoreWithNocheckOnCheckConstraints", Enabled = false },
//    new DacOption{ Name = "IgnoreWithNocheckOnForeignKeys", Enabled = false },
//    new DacOption{ Name = "AllowUnsafeRowLevelSecurityDataMovement", Enabled = false },
//    new DacOption{ Name = "IncludeCompositeObjects", Enabled = false },
//    new DacOption{ Name = "IncludeTransactionalScripts", Enabled = false },
//    new DacOption{ Name = "NoAlterStatementsToChangeClrTypes", Enabled = false },
//    new DacOption{ Name = "PopulateFilesOnFileGroups", Enabled = false },
//    new DacOption{ Name = "RegisterDataTierApplication", Enabled = false },
//    new DacOption{ Name = "RunDeploymentPlanExecutors", Enabled = false },
//    new DacOption{ Name = "ScriptDatabaseCollation", Enabled = false },
//    new DacOption{ Name = "ScriptDatabaseCompatibility", Enabled = false },
//    new DacOption{ Name = "ScriptDatabaseOptions", Enabled = false },
//    new DacOption{ Name = "ScriptDeployStateChecks", Enabled = false },
//    new DacOption{ Name = "ScriptFileSize", Enabled = false },
//    new DacOption{ Name = "ScriptNewConstraintValidation", Enabled = false },
//    new DacOption{ Name = "ScriptRefreshModule", Enabled = false },
//    new DacOption{ Name = "TreatVerificationErrorsAsWarnings", Enabled = false },
//    new DacOption{ Name = "UnmodifiableObjectWarnings", Enabled = false },
//    new DacOption{ Name = "VerifyCollationCompatibility", Enabled = false },
//    new DacOption{ Name = "VerifyDeployment", Enabled = false },
    
//    }
}
