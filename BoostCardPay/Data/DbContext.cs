using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class TransactionDbContext: DbContext {
    public DbSet<Transaction> Transactions { get; set; }
    public string DbPath { get; }
    public TransactionDbContext() {
        DbPath = "/home/ericp/Coding/cs_projects/BoostCardPay/Transactions.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}