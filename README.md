# GAME

## 进展

- 10.9 完成了简单的走进之后点击X弹出信息框，再点击X信息框关闭的功能
- 10.20将人物和物品栏更新到了之前上传的最新的代码中。
- 11.11人物和猫不会再发生碰撞，喂奶后可以通过shift切换人物与猫。修复了喂奶可能喂不进去的问题（目前为了方便起见，猫对人的判定距离比较大，可以远程喂奶）。修复了人物和猫因碰撞其他物体旋转的问题。猫可以简单完成走晾衣绳。待解决问题：跳跃操作手感比较差，需要改进。与场景中地面的交互可能需要修改，直接将“Ground” Tag的物体放在天上可能导致人物跳跃时撞头，不符合操作逻辑。第一个场景中需要猫跳跃时踩的空调机。
- 11.13 修改了猫和人的运动逻辑（目前人还有点bug没修）。完成了从晾衣绳一端滑动到另一端的动画，逻辑是持有衣架的人在接近晾衣绳的地方按下交互键x，则进入滑动动画，动画结束人物到达另一端。
修改了人物爬梯子的动画，即梯子落下之后开始爬（后面需要再加个梯子落下的判定）。
新增了老奶奶，老奶奶可被花瓶砸（目前的判定是花瓶与老奶娘的collider），砸中后进入摔倒动画；老奶奶若没有被花瓶砸，则在人物靠近老奶奶时进入被抓动画。
新增教主，完成了教主举手、教主举盘子活动、教主喝水动画，需要调用动画时，可直接获取教主的GameObject，通过GetComponent<Animation>获取Animation对象，该对象调用函数Play("动画名称")即可使教主产生相应动作。
新增教众和母亲，具有相同的动画：祈祷、喝水、死亡，可以通过上述Animation方法使得相应人物做出动作。
新增树下的教众，已经完成遇到人的逻辑，尚未完成调用对话框与人对话。目前尚未判定egg是否砸中教众。当人离教众过近时，触发教众说话，进入死亡界面。
未完成工作：调用死亡界面。下水道处的手的动画。
