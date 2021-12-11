using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitApp
{
    //dotnet test でテストができる
    
    //参考サイト
    //Xunitの概要
    //https://vicugna-pacos.github.io/dotnetcore/unittest/
    //Assertについて
    //https://blog.beachside.dev/entry/2018/11/20/183000
    //並行実行
    //https://qiita.com/inabe49/items/dd3bc053ba4865585d93

    /// <summary>
    /// サンプル単体テストコード
    /// </summary>
    /// Collectionをつけることで、同じ名称のCollectionは、同時に並列実行されないようにできる
    [Collection("SampleUnitTest")]
    public class SampleUnitTest : IDisposable
    {
        /// <summary>
        /// コンストラクタが初期処理となる
        /// これはテスト実行時毎回呼び出される
        /// </summary>
        public SampleUnitTest()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("開始時刻：" + dt.ToLongTimeString());
        }

        /// <summary>
        /// Disposeが終了処理となる
        /// これはテスト実行時毎回呼び出される
        /// </summary>
        public void Dispose()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("終了時刻：" + dt.ToLongTimeString());
        }
        /// <summary>
        /// 普通のテスト
        /// </summary>
        [Fact]
        public void PlusTest()
        {
            int x = 1 + 1;
            int y = 2;
            Assert.Equal(x, y);
        }

        /// <summary>
        /// Theoryで複数パターン(Part1)
        /// InlineDataの数だけテストを行う
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [Theory]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        public void MinusTest(int x, int y)
        {
            int xy1 = x - y;
            int xy2 = 1;
            Assert.Equal(xy1, xy2);
        }

        public static List<Object[]> param = new List<Object[]>(){
            new object[]{1, 2, 3},
            new object[]{2, 3, 5},
            new object[]{3, 4, 7},
        };

        /// <summary>
        /// Theoryで複数パターン(Part2)
        /// MemberDataを使用
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        [Theory]
        [MemberData(nameof(param))]
        public void SumTest(int x, int y, int z)
        {
            int sum = x + y + z;
            Assert.True(sum > 0);
        }
    }
}
