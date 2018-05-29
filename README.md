# AncientChinese
书生文
=====
## 文件说明
    带{}的单词表示需要替换的文本
### 文件相关接口
    111.230.253.18/api/file/get/{fileid}
    参数说明：
        fileid：文件的id
    结果类型：
        文件
### 字帖相关接口
    111.230.253.18/api/copybook/list
    参数说明：
        无
    结果类型：
        数组
    结果说明：
        {
            "Id": "c47c7b28-5514-4f80-91c1-f2f60d5f0c21",//字帖id
            "Title": "七发（简体）",//字帖名
            "BookType": "古文"//字帖类型
        }
     
        
    111.230.253.18/api/copybook/detail/{id}
    参数说明：
        id：字帖的id
    结果类型：
        数组
    结果说明：
        文件的id
### 名家欣赏相关接口
    111.230.253.18/api/appreciate/list
    参数说明：
        无
    结果类型：
        数组
    结果说明：
        {
            "ID": "444811bb-84b7-4ae5-91df-0f5b905f887d",
            "Title": "鸭头丸帖",
            "Times": "晋",
            "Author": "王献之"
        }
        
        
    111.230.253.18/api/appreciate/detail/{id}
    参数说明：
        id：名家欣赏的id
    结果类型：
        数组
    结果说明：
        文件的id
