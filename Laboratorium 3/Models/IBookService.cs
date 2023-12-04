﻿using Data.Entities;

namespace Laboratorium_3.Models
{
    public interface IContactService
    {
        int Add(Contact book);
        void Delete(int id);
        void Update(Contact book);
        List<Contact> FindAll();
        Contact? FindById(int id);
        List<OrganizationEntity> FindAllOrganizations();
        PagingList<Contact> FindPage(int pageIndex, int pageSize);
    }
}
