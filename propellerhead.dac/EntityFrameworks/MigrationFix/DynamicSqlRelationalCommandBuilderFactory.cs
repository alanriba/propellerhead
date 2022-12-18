using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace propellerhead.dac.EntityFrameworks.MigrationFix
{
	public class DynamicSqlRelationalCommandBuilderFactory : RelationalCommandBuilderFactory
    {
        public DynamicSqlRelationalCommandBuilderFactory(RelationalCommandBuilderDependencies dependencies) : base(dependencies)
        {
        }

        public override IRelationalCommandBuilder Create()
        {
            return new DynamicSqlRelationalCommandBuilder(Dependencies);
        }
    }
}

