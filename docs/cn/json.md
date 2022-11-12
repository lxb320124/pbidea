好用的 json for PB ,与 datawindow/datasore 无缝对接，能动态创建 dw/ds实现数据导入，也可以在现有dw/ds上按列匹配导入。
实时导入导出 json，速度快，效率高。
uo_json功能函数主要有4个，即:
1、Parse：将字符串转为JSON对象
2、ToString：将JSON对象转为字符串
3、Set：设置JSON对象或数组值
4、Get：获取JSON对象或数组值
在有多层嵌套的情况下，可以使用级联字符串直接取值。例如
```c++
[
{
"__rowid__":1,
"id":1.0,
"sj":"2020-02-17",
"sub":
[
{"__rowid__":1,"id":1.0,"mch":"菜1","dj":9.0,"je":7.0},
{"__rowid__":2,"id":1.0,"mch":"菜2","dj":1.0,"je":3.0},
{"__rowid__":3,"id":1.0,"mch":"菜3","dj":7.0,"je":1.0},
{"__rowid__":4,"id":1.0,"mch":"菜4","dj":5.0,"je":9.0}
]
}
]
```

要取得第一行数组"菜3"下面的dj,可以这样写key字符串:
```c++
deciaml ld_dj
json.Get("/0/sub/2/dj",ref ld_dj)
```
"/0/sub/2/dj"这个串里，第一个0表示是大数组的第1行数据，sub表示第一行数据是JSON，取其sub的值，sub的值是一个JSON数组。然后跟着的2表示取子数组的第3行数据，key为dj,取值类型为 decimal。
***这里注意，与PB的数组下限从1开始到n结束不同，这里JSON数组下限是0从开始，n-1结束。