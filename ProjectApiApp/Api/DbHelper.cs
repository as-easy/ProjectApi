using ProjectApiApp.EFCore;
using System.Linq;

namespace ProjectApiApp.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<ItemModel> GetItems()
        {
            List<ItemModel> response = new List<ItemModel>();
            var dataList = _context.Items.ToList();
            dataList.ForEach(row => response.Add(new ItemModel()
            {
                id = row.Id,
                code = row.Code,
                name = row.Name,
                parent_id = row.ParentId
            }));
            return response;
        }

        public ItemModel GetItemById(int id)
        {
            ItemModel response = new ItemModel();
            var row = _context.Items.Where(d => d.Id.Equals(id)).FirstOrDefault();
            return new ItemModel()
            {
                id = row.Id,
                code = row.Code,
                name = row.Name,
                parent_id = row.ParentId
            };
        }

        /// <summary>
        /// It serves the POST
        /// </summary>
        public void SaveItem(ItemModel itemModel)
        {
            var dbTable = new Item();

            if (String.IsNullOrWhiteSpace(itemModel.name))
                throw new Exception("Наименование объекта не может быть пустым");
            if (String.IsNullOrWhiteSpace(itemModel.code))
                throw new Exception("Шифр объекта не может быть пустым");

            dbTable.Name = itemModel.name;
            dbTable.Code = itemModel.code;

            dbTable.Parent = itemModel.parent_id == null ? null : _context.Items.Where(f => f.Id.Equals(itemModel.parent_id)).FirstOrDefault();

            _context.Items.Add(dbTable);

            _context.SaveChanges();
        }

        /// <summary>
        /// It serves the PUT
        /// </summary>
        public void UpdateItem(ItemModel itemModel)
        {
            var dbTable = _context.Items.Where(d => d.Id.Equals(itemModel.id)).FirstOrDefault();

            if (dbTable == null) return;

            if (!String.IsNullOrWhiteSpace(itemModel.name))
                dbTable.Name = itemModel.name;
            if (!String.IsNullOrWhiteSpace(itemModel.code))
                dbTable.Code = itemModel.code;

            if (itemModel.parent_id != null)
            {
                if(itemModel.parent_id == dbTable.Id)
                    throw new Exception("Нельзя ссылаться на свой id");

                List<int> parents = new List<int>();
                GetAllParentsId((int)itemModel.parent_id, ref parents);
                if (parents.Count != 0 && parents.Contains(dbTable.Id))
                    throw new Exception("Нельзя ссылаться на id потомка");
                else
                    dbTable.Parent = _context.Items.Where(f => f.Id.Equals(itemModel.parent_id)).FirstOrDefault();
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Получение всех родителей
        /// </summary>
        public void GetAllParentsId(int? parent_id, ref List<int> parents)
        {            
            if (parent_id == null)
                return;
            
            var current = _context.Items.Where(f => f.Id.Equals(parent_id)).FirstOrDefault();
            if (current == null || current.ParentId == null) return;

            parents.Add((int)current.ParentId);
            GetAllParentsId(current.ParentId, ref parents);
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteItem(int id)
        {
            var item = _context.Items.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// It serves the POST
        /// </summary>
        public void SaveProject(ProjectModel projectModel)
        {
            var dbTable = new Project();

            if (String.IsNullOrWhiteSpace(projectModel.name))
                throw new Exception("Наименование проекта не может быть пустым");
            if (String.IsNullOrWhiteSpace(projectModel.code))
                throw new Exception("Шифр проекта не может быть пустым");

            dbTable.Name = projectModel.name;
            dbTable.Code = projectModel.code;

            _context.Projects.Add(dbTable);            

            _context.SaveChanges();
        }

        /// <summary>
        /// It serves the PUT
        /// </summary>
        public void UpdateProject(ProjectModel projectModel)
        {
            var dbTable = _context.Projects.Where(d => d.Id.Equals(projectModel.id)).FirstOrDefault();

            if (dbTable == null) return;

            if (!String.IsNullOrWhiteSpace(projectModel.name))
                dbTable.Name = projectModel.name;
            if (!String.IsNullOrWhiteSpace(projectModel.code))
                dbTable.Code = projectModel.code;

            Item item = projectModel.item_id == null ? null : _context.Items.Where(f => f.Id.Equals(projectModel.item_id)).FirstOrDefault();

            if (item != null)
                dbTable.Items.Add(item);

            _context.SaveChanges();
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProject(int id)
        {
            var project = _context.Projects.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }
    }
}

