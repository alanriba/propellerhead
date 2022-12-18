using System;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text.RegularExpressions;

namespace propellerhead.dac.EntityFrameworks.MigrationFix
{
    class DynamicSqlRelationalCommandBuilder : RelationalCommandBuilder
    {
        private readonly string _execRequiringStatements = @"(SET IDENTITY_INSERT|^(UPDATE|(CREATE|ALTER) PROCEDURE|ALTER TABLE|CREATE (UNIQUE )?INDEX|(CREATE|DROP) VIEW)|^DELETE FROM)";
        public DynamicSqlRelationalCommandBuilder(RelationalCommandBuilderDependencies dependencies)
            : base(dependencies)
        {
        }

        public override IRelationalCommand Build()
        {
            var commandText = ToString();

            if (Regex.IsMatch(commandText, _execRequiringStatements, RegexOptions.IgnoreCase))
                commandText = "EXECUTE ('" + commandText.Replace("'", "''") + "')";

            return new RelationalCommand(Dependencies, commandText, Parameters);
        }
    }
}

