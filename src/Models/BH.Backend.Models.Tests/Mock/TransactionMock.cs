﻿using BH.Backend.Models.Db;
using BH.Backend.Models.Enums;

namespace BH.Backend.Models.Tests.Mock
{
    public class TransactionMock
    {
        public static Transaction Transaction_Valid = new Transaction()
        {
            Amount = Convert.ToDouble(10),
            TransactionType = TransactionType.Debit,
            AccountId = Guid.NewGuid()
        };

        public static Transaction Transaction_Invalid_InvalidType = new Transaction()
        {
            TransactionType = TransactionType.None,
            AccountId = Guid.NewGuid()
        };

        public static Transaction Transaction_Invalid_Amount = new Transaction()
        {
            Amount = Convert.ToDouble(-10),
            TransactionType = TransactionType.Debit,
            AccountId = Guid.NewGuid()
        };

        public static Transaction Transaction_Invalid_EmptyAccountId = new Transaction()
        {
            Amount = Convert.ToDouble(10),
            TransactionType = TransactionType.Debit
        };
    }
}
