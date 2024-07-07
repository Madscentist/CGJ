using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DialogBox
{
    public static class DialogUtil
    {
        public static Dictionary<DialogActionType, System.Type> TypeDict = new()
        {
            [DialogActionType.ShowText] = typeof(DA_ShowText),
            [DialogActionType.Wait] = typeof(DA_Wait),
            [DialogActionType.WaitButtonPressed] = typeof(DA_WaitButtonPressed),
            [DialogActionType.ClearText] = typeof(DA_ClearText),
            [DialogActionType.NewLine] = typeof(DA_NewLine),
            [DialogActionType.SetBG] = typeof(DA_SetBG),
        };

        public static DialogBox CreateDialogBox(UI_DialogBox prefab = null)
        {
            if (prefab == null)
                prefab = GameSetting.UI_DialogBox_Default;
            DialogBox box = new();
            var uiInstance = CreateUI_DialogBox(prefab);
            box.Init(uiInstance);
            uiInstance.gameObject.SetActive(false);
            DialogBoxManager.AddBox(box);
            return box;
        }

        public static UI_DialogBox CreateUI_DialogBox(UI_DialogBox prefab)
        {
            if (prefab == null)
                return null;
            return GameObject.Instantiate(prefab, UIManager.Canvas.transform);
        }

        public static void StartDialog(this DialogBox dialogBox, uint id)
        {
            var data = DialogConfig.Instance.GetData(id);
            if (data == null)
                return;
            dialogBox.StartDialog(data);
        }

    }
}

/*
背景故事文本
文本1——碎骨头：
脚的附近好像有些白色的物体, 形状不固定, 质地也不是很坚硬, 一踩就碎了, 感觉应该有一段时间了, 风化程度有点厉害
这些物体看起来有点像是骨头, 野兽的骨头好像没有这个尺寸的, 难道是……

文本2——冒险者过期魔药与腰带：
这些东西是？
好像是冒险者的装备, 看起来像是腰带, 不过都破破烂烂了, 远处还有个瓶子, 应该是魔药吧
额, 药水颜色都变了, 都过期了, 不知道还有没有效果
要不拿着吧？毕竟也不知道什么时候能走出去
不过还是算了吧, 也不知道喝了会不会拉肚子……
不过, 不得不提冒险者套装性价比还真是高啊, 魔药瓶子都摔到那么远了也没破

文本3——生命之泉广场：
“嘶”
在察觉到自己惊呼出声的瞬间, 我赶紧闭上嘴躲在了阴影处观察情况, 哪怕在祭坛旁边的两个怪物被惊扰后来追杀我, 我也可以随时逃跑
我身处在这个暗无天日的迷宫的这段时间时间里, 这种警戒意识已经刻进了我的DNA里了
过了一段时间后, 那两个怪物好像没有任何动静, 我靠近一看
怎么是两个雕像啊, 还做这么逼真, 长得那么像之前的小魅魔, 我还以为是成熟体怪物呢, 吓我一跳
咦, 怎么感觉浑身暖洋洋的, 疲惫和伤势都消失了一样, 是这个祭坛一样的东西的效果吗, 要是能一直呆在这就好了

文本4——纸条：
左左右*涂掉*  左右右左前*涂掉*  左右右……
剩下的看不清了, 被一些液体挡住了好像是某个冒险者遗留下来的手写地图, 不过既然掉在这个地方, 纸上还有血, 这个冒险者应该已经……
我一定会拿到钥匙走出这里的, 店主还在等着我
你的遗产就由我带走了, 到时我在外面用这个纸条帮你立个衣冠冢吧, 毕竟也找不到别的东西了

文本5——临死前：
不行了, 意识已经开始模糊了, 眼睛睁不开了, 手脚也不听使唤了, 感觉身体有点冷
我是要死了吗？
不过感觉又开始暖了, 感觉像有人抱着我, 好像还能听到店主的声音, 闻到店主的香味
难道这就是回光返照吗？感觉还不错呢
如果能成功进店就好了, 店主那么漂亮, 好想和店主一起……
意识要……



开场文本：
主角：这里是哪里, 怎么有个门被那么多锁锁住
艾莉丝（NPC）：您好, 这位英俊的冒险者, 我叫艾莉丝, 这里是我姐姐莉莉丝的店铺我姐姐不知道怎么搞的, 把自己反锁在店铺里了, 现在出不来了我看您应该是斥候, 不知道是否可以麻烦您去帮我们把钥匙找回来, 我们姐妹二人必定会报答您的恩情
主角：我副职业是盗贼, 我会开锁, 让我来试试撬了这些锁吧
艾莉丝：没用的, 店铺前的这些并不是普通锁, 它是锁魔法的一个具体体现, 必须要有对应的秘钥才能解开这些防护姐姐之前把秘钥掉在山洞里了, 里面还有一些魔物, 我没法找回全部钥匙
我之前自己找了一把钥匙, 现在防护魔法阵已经解锁了50%了
冒险者大人, 您是斥候, 可以简单找到钥匙的所在地, 还能避开怪物, 可以求您帮帮我们吗？我和莉莉丝姐姐会在店铺里好好报答您的, 非常刺激的那种报答~
（播放脱衣服的音效）
主角：保证完成任务! 等我回来和你们在店里好好地玩玩!
艾莉丝：冒险者大人, 虽然由请求你的我说这话可能不太合适, 真的没关系吗, 很危险的啊!
主角：没关系, 既然追求刺激, 那就贯彻到底! 等我回家!

第一关后：
主角：艾莉丝! 我回来了, 我带着钥匙回来了, 让我用钥匙开了你们的锁!
艾莉丝：太好了, 有了这把钥匙又可以解开25%的锁了, 马上就可以进店铺了
冒险者大人, 谢谢你的帮助还有一把钥匙在山洞里, 麻烦您了!

第二关后：
艾莉丝!我回来了, 这下我们可以进门了吧!
艾莉丝：太好了, 防护魔法阵现在解锁了87.5%了, 很快就能进门了!
冒险者大人, 下一把钥匙也在山洞里, 拜托您了!
主角：还有钥匙啊, 好吧……
*/