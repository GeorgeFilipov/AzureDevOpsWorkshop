﻿using System;

namespace ProjectWithMigrations.Data
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
    }
}
