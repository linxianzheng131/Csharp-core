using System;

class Program
{
    // 用来保存一个 ref int
    static ref int savedRef;

    static void Main()
    {
        // 这里会编译报错：无法使用本地变量 'a' 作为 ref 返回，因为它可能已被销毁
        savedRef = Test();
    }

    static ref int Test()
    {
        // 局部变量 a，在方法结束后栈帧销毁
        int a = 100;

        // 试图返回 a 的引用 —— 编译器直接禁止
        return ref a;
    }
}