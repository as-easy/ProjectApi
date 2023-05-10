# ProjectApi
Api для добавления дерева объектов

getItems - Получение всех объектов<br/>
getItemById - Получение объектов по id<br/>
saveItem - Добавление нового объекта (параметры в Json-body - code, name, parent_id)<br/>
updateItem - Обновление объекта (параметры в Json-body - id, code, name, parent_id)<br/>
deleteItem - Каскадное удаление объектов по id узла<br/>

В проект можно добавить любое количество объектов<br/>
saveProject - Добавление нового проекта (параметры в Json-body - code, name)<br/>
updateProject - Обновление проекта (параметры в Json-body - id, code, name, item_id)<br/>
deleteProject - Удаление проекта по id (не приводит к удаление дерева объектов<br/>

Коллекцию с методами можно импортировать в Postman (внутри решения "Папка с коллекцией готовых методов в Postman")

Чтобы бд появилась в базе данных postgresql нужно мигрировать через Package Manager Console в VS, например командой Add-Migration UpdateDatabase3, и далее ввести команду Update-Database
Создаться бд с тремя таблицами (project, item, ItemProject)

В файле appsettings.json - необходимо прописать креды к бд 
