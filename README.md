# generate_table_class_by_template
利用範本檔_大量產生以table命名為前綴的service、models檔案



或許還可以搭配這個語法 查出近期新開的table

```
SELECT [name] ,create_date ,modify_date
FROM sys.tables
order by create_date desc
```
