using Behavioral.ChainOfResponsibility;
using NUnit.Framework;
using System;

namespace Behavioral.Tests
{
    public class ChainOfResponsibilityTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FunctionalTest()
        {
            Accountant accountant = InitAccountantWithChain();

            Invoice emptyInvoice = new Invoice();
            accountant.Approve(emptyInvoice);
            Assert.IsTrue(emptyInvoice.IsApproved);

            Invoice maxInvoice = new Invoice() { TotalAmount = int.MaxValue };
            accountant.Approve(maxInvoice);
            Assert.IsTrue(maxInvoice.IsApproved);

            Contract emptyContract = new Contract();
            accountant.Approve(emptyContract);
            Assert.IsTrue(emptyContract.IsApproved);

            Contract longContract = new Contract() { Duration = new TimeSpan(500, 0, 0, 0) };
            accountant.Approve(longContract);
            Assert.IsTrue(longContract.IsApproved);

            Contract heavyContract = new Contract() { MonthlyPayment = int.MaxValue };
            accountant.Approve(heavyContract);
            Assert.IsTrue(heavyContract.IsApproved);
        }

        [Test]
        public void WhenInvoiceMoreMaxShouldAccountanNotApprove()
        {
            Accountant accountant = InitAccountantWithChain();

            Assert.IsFalse(accountant.CanApprove(new Invoice { TotalAmount = int.MaxValue }));
        }

        private Accountant InitAccountantWithChain()
        {
            CEO ceo = new CEO();
            COO coo = new COO() { NextApprover = ceo };
            PrincipalAccountant principalAccountant = new PrincipalAccountant() { NextApprover = coo };
            Accountant accountant = new Accountant() { NextApprover = principalAccountant };
            return accountant;
        }
    }
}