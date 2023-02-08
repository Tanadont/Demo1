using System.Text;
using Demo1.Data;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Services
{
    public class MasProjectService : IMasProject
    {
        private readonly DataContext db;

        public MasProjectService(DataContext db)
        {
            this.db = db;
        }

        public ApiResponse Get(int id)
        {
            ApiResponse response = new ApiResponse();
            var result = this.db.FindMasProjects.FromSqlRaw(
                " SELECT mp.project_id AS Id, mp.project_code AS Code, mp.project_name_th AS NameTh, mp.project_name_en AS NameEn, " +
                " mu.unit_no AS UnitNo, mu.house_no AS HouseNo " +
                $" FROM dbo.mas_project AS mp join dbo.mas_unit AS mu ON mp.project_id = mu.mpj_project_id WHERE mp.project_id = ${id} ").First();
            response.data = result;
            return response;
        }

        public ApiResponse GetAll(Query query)
        {
            ApiResponse response = new ApiResponse();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT mp.project_id AS Id, mp.project_code AS Code, mp.project_name_th AS NameTh, mp.project_name_en AS NameEn, " +
                " mu.unit_no AS UnitNo, mu.house_no AS HouseNo " +
                " FROM dbo.mas_project AS mp join dbo.mas_unit AS mu ON mp.project_id = mu.mpj_project_id WHERE 1 = 1 ");

            if(query.Search.Trim().Length > 0 ) {
                stringBuilder.AppendFormat("AND (project_name_en LIKE '%{0}%' OR project_name_th LIKE N'%{0}%') ", query.Search);
            }

            // query รอบเดียว น้องดิว
            var totalRecords = this.db.FindMasProjects.FromSqlRaw(stringBuilder.ToString()).ToList();
            if(totalRecords.Count > 0 )
            {
                var result = totalRecords.Skip(query.Limit * query.Skip).Take(query.Limit).ToList();
                response.data = result;
            }
            response.statusCode = "200";
            response.currentPage = query.Skip;
            response.pageSize = query.Limit;
            response.totalRecords = totalRecords.Count;
            return response;
        }

    }
}
