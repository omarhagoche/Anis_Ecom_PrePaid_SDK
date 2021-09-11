using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using PrePaid_SDK.Entities.ECOM.AnisLY.Categories;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class SubCategory
    {
        public SubCategory()
        {

        }
        public List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories> GET(long CategoryID_FK)
        {
            try
            {
                List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories> SubcategoriesList = new List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories>();
                DAL.Inventory.Data_SubCategories DAL = new DAL.Inventory.Data_SubCategories();
                var DT = DAL.Select(CategoryID_FK);
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow Subcategory in DT.Rows)
                    {
                        SubcategoriesList.Add(
                            new Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories()
                            {
                                SubCategoryID_PK = int.Parse(Subcategory["SubCategoryID_PK"].ToString()),
                                CategoryID_FK = int.Parse(Subcategory["CategoryID_FK"].ToString()),
                                SubCategoryCode = Subcategory["SubCategoryCode"].ToString(),
                                SubCategoryName = Subcategory["SubCategoryName"].ToString(),
                                SubCategoryDescription = Subcategory["SubCategoryDescription"].ToString(),
                                SubGategory_Logo = Subcategory["SubGategory_Logo"] as byte[],
                                SubCategory_Available = bool.Parse(Subcategory["SubCategory_Available"].ToString()),
                                UsageCounter = int.Parse(Subcategory["UsageCounter"].ToString())
                            }
                        );
                    }

                    return SubcategoriesList;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories GET_SubCategoryID_PK(long SubCategoryID_PK)
        {
            try
            {
                Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories Subcategories = new Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories();
                DAL.Inventory.Data_SubCategories DAL = new DAL.Inventory.Data_SubCategories();
                return DAL.Select_SubCategoryID_PK(SubCategoryID_PK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories> GET()
        {
            try
            {
                List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories> SubcategoriesList = new List<Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories>();
                DAL.Inventory.Data_SubCategories DAL = new DAL.Inventory.Data_SubCategories();
                var DT = DAL.Select();
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow Subcategory in DT.Rows)
                    {
                        SubcategoriesList.Add(
                            new Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories()
                            {
                                SubCategoryID_PK = int.Parse(Subcategory["SubCategoryID_PK"].ToString()),
                                CategoryID_FK = int.Parse(Subcategory["CategoryID_FK"].ToString()),
                                SubCategoryCode = Subcategory["SubCategoryCode"].ToString(),
                                SubCategoryName = Subcategory["SubCategoryName"].ToString(),
                                SubCategoryDescription = Subcategory["SubCategoryDescription"].ToString(),
                                SubGategory_Logo = Subcategory["SubGategory_Logo"] as byte[],
                                SubCategory_Available = bool.Parse(Subcategory["SubCategory_Available"].ToString()),
                                UsageCounter = int.Parse(Subcategory["UsageCounter"].ToString())
                            }
                        );
                    }

                    return SubcategoriesList;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.DB.Entitie_StoredProcedure SP_UPs(Entities.DB.PrePaidCardsSystemDB.Inventory.Data_SubCategories Subcategory)
        {
            try
            {
                DAL.Inventory.Data_SubCategories DAL = new DAL.Inventory.Data_SubCategories();
                return DAL.SP_UPs(Subcategory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_UsageCounter(long SubCategoryID_PK)
        {
            try
            {
                DAL.Inventory.Data_Categories categories = new DAL.Inventory.Data_Categories();
                DAL.Inventory.Data_SubCategories subCategories = new DAL.Inventory.Data_SubCategories();

                var SubCat = subCategories.Select_SubCategoryID_PK(SubCategoryID_PK);
                subCategories.Update_UsageCounter(SubCat.SubCategoryID_PK, SubCat.UsageCounter+1);

                var cat = categories.Select(GET_SubCategoryID_PK(SubCategoryID_PK).CategoryID_FK);
                categories.Update_UsageCounter(cat.CategoryID_PK, cat.UsageCounter+1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
