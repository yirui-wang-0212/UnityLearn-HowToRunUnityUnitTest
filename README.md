# HowToRunUnityUnitTest



## 说明

- 本文使用Unity Editor自带的单元测试工具Unity Test Runner进行单元测试。

- 本文主要是对[raywenderlich.com](https://www.raywenderlich.com/)中的[Unity Tutorials](https://www.raywenderlich.com/unity)教程[Introduction To Unity Unit Testing](https://www.raywenderlich.com/9454-introduction-to-unity-unit-testing)的中文翻译与补充。



## 参考

- 教程：[Introduction To Unity Unit Testing](https://www.raywenderlich.com/9454-introduction-to-unity-unit-testing)

- Unity官方用户手册：[Unity Test Runner](https://docs.unity3d.com/Manual/testing-editortestsrunner.html)



## 项目

- [Crashteroids](https://github.com/Charon0622/HowToRunUnityUnitTest/tree/master/Crashteroids)下的[Crashteroids Starter](https://github.com/Charon0622/HowToRunUnityUnitTest/tree/master/Crashteroids/Crashteroids%20Starter)为未添加测试的原始项目，供大家按照教程为项目添加测试。

- [Crashteroids](https://github.com/Charon0622/HowToRunUnityUnitTest/tree/master/Crashteroids)下的[Crashteroids Final](https://github.com/Charon0622/HowToRunUnityUnitTest/tree/master/Crashteroids/Crashteroids%20Final)为按照教程添加测试后的项目。

- 也可以参考本人在学习教程时创建的项目[Crashteroids](https://github.com/Charon0622/Crashteroids/tree/master/Crashteroids)，里面的测试代码附有较为详细的注释。



## 教程：Unity单元测试简介

### 1. 什么是单元测试？

**单元测试**是指对软件中的最小可测试单元进行检查和验证。对于单元测试中单元的含义，一般来说，要根据实际情况去判定其具体含义。总的来说，单元就是人为规定的最小的被测功能模块，单元测试应该一次只测试一个“事物”。

测试人员应该设计一个单元测试来验证一个小的逻辑代码片段是否完全按照预期执行。

请参考以下示例：

```c#
public string name = ""
public void UpdateNameWithCharacter(char: character)
{
    // 1
    if (!Char.IsLetter(character))
    {
        return;
    }

    // 2
    if (name.Length > 10)
    {
        return;
    }

    // 3
    name += character;
}
```

1. 如果```character```不是字母，则会提前退出函数，并且不会将字符添加到字符串中。
2. 如果```name```的长度大于10，则会阻止用户添加另一个字符。
3. 否则将```character```添加到```name```的结尾。

这个方法是一个可以进行单元测试的很好的例子。

#### 示例单元测试

对于```UpdateNameWithCharacter```方法，需要仔细考虑测试要进行的工作，并为它们提供名称。名称应清楚说明测试的内容：

```UpdateNameDoesntAllowCharacterAddingToNameIfNameIsTenOrMoreCharactersInLength```

```UpdateNameAllowsLettersToBeAddedToName```

```UpdateNameDoesntAllowNonLettersToBeAddedToName```

#### 测试套件

一个**测试套件**包含一组相关的单元测试（如战斗模块单元测试）。如果测试套件中的任何单个测试失败，则整个测试套件将失败。

![TestSuite](Pic/TestSuite.png)

### 3. 启动游戏

打开