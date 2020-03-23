// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClassMap.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.BusinessBase.Infrastructure
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface for class mapping information.
    /// </summary>
    public interface IClassMap
    {
        /// <summary>
        /// Gets or sets the set of primary key column names.
        /// </summary>
        IList<string> PrimaryKeyColumnNames { get; set; }

        /// <summary>
        /// Gets or sets the name of the schema the mapped table belongs to.
        /// </summary>
        string SchemaName { get; set; }

        /// <summary>
        /// Gets or sets the name of the mapped table.
        /// </summary>
        string TableName { get; set; }
    }
}
