using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;
using DAL.UnitOfWork;
using DTOs;

namespace BLL
{
    public class RoleBL
    {
        /// <summary>
        /// This function returns the list of all available roles in the Role table.
        /// </summary>
        /// <returns></returns>

        public List<RoleDTO> GetAllRole()
        {
            List<RoleDTO> roleList = new List<RoleDTO>();
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    List<Role> list = uow.RoleRepo.GetAll().ToList();
                    foreach (var row in list)
                    {
                        roleList.Add(new RoleDTO()
                        {
                            RoleId = row.RoleId,
                            Role1 = row.Role1,
                            Active = row.Active,
                            RecordStatus = row.RecordStatus,
                            CreatedBy = row.CreatedBy,
                            CreatedDate = row.CreatedDate,
                            LastModifiedBy = row.LastModifiedBy,
                            LastModifiedDate = row.LastModifiedDate
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return roleList;
        }
    }
}
