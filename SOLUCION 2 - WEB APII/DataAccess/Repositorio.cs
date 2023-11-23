﻿using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

public class Repositorio<T> : IRepositorio<T> where T : class
{
    protected DbContext Context { get; set; }

    public T Add(T entity)
    {
        Context.Set<T>().Add(entity);
        return entity;
    }


    public void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
    }


    public void Update(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }


    public void Save()
    {
        Context.SaveChanges();
    }
}
