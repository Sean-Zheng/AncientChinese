# AncientChinese
书生文
=====
## 文件说明
    带{}的单词表示需要替换的文本
### 文件相关接口
    111.230.253.18/api/file/get/{fileid}
    方法:get
    参数说明：
        fileid：文件的id
    结果类型：
        文件
### 字帖相关接口
    111.230.253.18/api/copybook/typelist
    作用:获取字帖类型列表
    方法:get
    参数说明：
        无
    结果类型：
        数组
    结果说明：
        {
            "TypeId": 0,
            "TypeName": "古文"
        }
        
    111.230.253.18/api/copybook/list
    作用:获取字帖列表
    方法:get
    参数说明：
        无
    结果类型：
        数组
    结果说明：
        {
            "Id": "c50b6067-dbac-4a43-83c2-3b4b4918aea6",
            "Title": "为有",
            "BookType": "唐诗",
            "Author": "李商隐",
            "FontType": "繁体",
            "Content": "    为有云屏无限娇，凤城寒尽怕春宵。\n    无端嫁得金龟婿，辜负香衾事早朝。 "
        }
     
    111.230.253.18/api/copybook/list?type={typeId}
    作用:通过字帖类型获取字帖列表
    方法:get
    参数说明：
        typeId:字帖类型
        
    111.230.253.18/api/copybook/detail/{id}
    作用:获取字帖的图片列表数据
    方法:get
    参数说明：
        id：字帖的id
    结果类型：
        数组
    结果说明：
        文件的id
### 名家欣赏相关接口
    111.230.253.18/api/appreciate/list
    方法:get
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
    111.230.253.18/api/appreciate/list
    方法:get
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
        
    111.230.253.18/api/appreciate/list
    方法:get
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
    方法:get
    参数说明：
        id：名家欣赏的id
    结果类型：
        数组
    结果说明：
        文件的id
