using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace LZ.BusinessLayer.efdemo.Authorization
{
    public static class Operations
    {
        public static OperationAuthorizationRequirement OrderProtection = new OperationAuthorizationRequirement { Name = "Order" };
        public static OperationAuthorizationRequirement ProfileProtection = new OperationAuthorizationRequirement { Name = "Profile" };
        public static OperationAuthorizationRequirement CustomerProtection = new OperationAuthorizationRequirement { Name = "Customer" };
        public static OperationAuthorizationRequirement RefundProtection = new OperationAuthorizationRequirement { Name = "Refund" };
        public static OperationAuthorizationRequirement StoreCreditProtection = new OperationAuthorizationRequirement { Name = "StoreCredit" };
    }
}
