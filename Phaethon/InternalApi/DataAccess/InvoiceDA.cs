﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Core.Model;

namespace InternalApi.DataAccess
{
    public class InvoiceDa
    {
        internal void CreateOrUpdate(DatabaseContext db, Invoice invoice)
        {
            db.Invoices.AddOrUpdate(invoice);
            db.SaveChanges();
        }

        internal Invoice GetInvoice(DatabaseContext db, int id)
        {
            return db.Invoices
                .Include(x => x.Receiver.Company)
                .Include(x => x.Sender.Company)
                .SingleOrDefault(x => x.ID == id);
        }

        internal List<Invoice> GetInvoices(DatabaseContext db, int numOfRecords, int selectedCompany, string name, int selectedDate,  DateTime from, DateTime to, string docNumber)
        {
            return db.Invoices
                    .Include(x => x.Sender.Company)
                    .Include(x => x.Receiver.Company)
                    .Where(x => selectedCompany == 0 && x.Receiver.Company.Name.Contains(name) ||
                                selectedCompany == 1 && x.Sender.Company.Name.Contains(name))
                    .Where(x => selectedDate == 0 && from <= x.PrescriptionDate && x.PrescriptionDate <= to ||
                                selectedDate == 1 && from <= x.ReceptionDate && x.ReceptionDate <= to ||
                                selectedDate == 2 && from <= x.PaymentDate && x.PaymentDate <= to)
                    .Where(x => x.DocNumber.Contains(docNumber))
                    .OrderByDescending(x => x.ID)
                    .Take(numOfRecords)
                    .AsEnumerable()
                    .Select(invoice => new { invoice, Sum = db.Elements.Where(x => x.Invoice_ID == invoice.ID).Select(x => x.Item.IncomingPrice).DefaultIfEmpty(0).Sum(x => x)})
                    .Select(x => { x.invoice.Sum = x.Sum; return x.invoice; })
                    .ToList();
        }

        internal bool Delete(DatabaseContext db, Invoice invoice)
        {
            db.Invoices.Remove(invoice);
            return db.SaveChanges() > 0;
        }
    }
}
