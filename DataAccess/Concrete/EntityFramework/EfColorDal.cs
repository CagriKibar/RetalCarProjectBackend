using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RecaptProjectContext context= new RecaptProjectContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RecaptProjectContext context=new RecaptProjectContext())
            {
                var deletedEntity = context.Entry(entity);
                // silmek için değişken oluşturduk daha sonra context değerimize giriş izni verdik.
                deletedEntity.State = EntityState.Deleted; 
                //deleted state(durum) diyerek EntityState.Deleted linq sorgusunu çağırdık.
                context.SaveChanges();
                //context için yapılanları kaydet dedik. 
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Color entity)
        {
            using (RecaptProjectContext context = new RecaptProjectContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
