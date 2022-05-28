using Lib_Moq_XUnit.Interface;
using Moq;
using System;
using Xunit;

namespace Lib_Moq_XUnit
{
    /// <summary>
    /// Moqクラスを扱ったテスト一覧
    /// 参考サイト:https://qiita.com/usamik26/items/42959d8b95397d3a8ffb
    /// </summary>
    public class MoqTest
    {
        [Fact]
        public void 固定値を返す()
        {
            var mock = new Mock<IHoge>();
            mock.SetupGet(x => x.Name)
                .Returns("xyz");
            Assert.Equal("xyz", mock.Object.Name);
        }

        [Fact]
        public void 値をセットする()
        {
            var mock = new Mock<IHoge>();
            mock.SetupProperty(x => x.Name, "xyz");
            Assert.Equal("xyz", mock.Object.Name);

            mock.Object.Name = "123";
            Assert.Equal("123", mock.Object.Name);
        }

        [Fact]
        public void 特定の入力に特定の出力を返す()
        {
            var mock = new Mock<IHoge>();
            mock.Setup(x => x.DoSomething("abc"))
                .Returns(true);
            Assert.True(mock.Object.DoSomething("abc"));
        }

        [Fact]
        public void 入力の条件を指定する()
        {
            var mock = new Mock<IHoge>();

            // 10文字未満であればtrueを返す
            // Itには色々なメソッドがあるので確認する
            mock.Setup(x => x.DoSomething(It.Is<string>(x => x.Length < 10)))
                .Returns(true);

            Assert.True(mock.Object.DoSomething("1"));
            Assert.True(mock.Object.DoSomething("12"));
            Assert.True(mock.Object.DoSomething("123"));
            Assert.True(mock.Object.DoSomething("1234"));
            Assert.True(mock.Object.DoSomething("12345"));
            Assert.True(mock.Object.DoSomething("123456"));
            Assert.True(mock.Object.DoSomething("1234567"));
            Assert.True(mock.Object.DoSomething("12345678"));
            Assert.True(mock.Object.DoSomething("123456789"));
            Assert.False(mock.Object.DoSomething("1234567890"));
        }

        /// <summary>
        /// TODO:ここだけエラーになってしまっていた
        /// </summary>
        //[Fact]
        //public void 入力内容に応じた出力を返す()
        //{
        //    var mock = new Mock<IHoge>();
        //    mock.Setup(x => x.DoSomething2(It.IsAny<string>()))
        //        .Returns(s => s.ToUpper());

        //    mock.Object.DoSomething("abc");
        //}

        [Fact]
        public void プロパティの定義を楽にする()
        {
            var mock = new Mock<IHoge>();
            mock.SetupAllProperties();

            mock.Object.Name = "xyz";
            Assert.Equal("xyz", mock.Object.Name);
        }

        [Fact]
        public void 例外を発生させる()
        {
            var mock = new Mock<IHoge>();
            mock.Setup(x => x.DoSomething("abc"))
                .Throws<InvalidOperationException>();
            Assert.Throws<InvalidOperationException>(() => mock.Object.DoSomething("abc"));
        }

        [Fact]
        public void 返す値を変化させる()
        {
            var mock = new Mock<IHoge>();
            mock.SetupSequence(x => x.DoSomething("abc"))
                .Returns(true)
                .Returns(false)
                .Throws<InvalidOperationException>();

            // 順番にtrue, false, errorとなる
            Assert.True(mock.Object.DoSomething("abc"));
            Assert.False(mock.Object.DoSomething("abc"));
            Assert.Throws<InvalidOperationException>(() => mock.Object.DoSomething("abc"));
        }

        [Fact]
        public void 呼び出されたかどうかを検証する()
        {
            var mock = new Mock<IHoge>();
            mock.Setup(x => x.DoSomething("abc"))
                .Returns(true);

            // 少なくとも一回呼び出されていること
            // 呼び出されていなかった場合は例外を吐き出す
            try
            {
                mock.Verify(x => x.DoSomething("abc"), Times.AtLeastOnce());
                
                // エラーを吐き出していなければここでテスト失敗になる
                Assert.True(false);
            }
            catch(Exception ex)
            {
                Assert.NotNull(ex);
            }

            mock.Object.DoSomething("abc");
            mock.Verify(x => x.DoSomething("abc"), Times.AtLeastOnce());
        }

        [Fact]
        public void 呼び出された際の処理を記述する()
        {
            var mock = new Mock<IHoge>();
            var x = 1;
            var y = 2;
            
            // Callbackで処理が実行される
            mock.Setup(x => x.DoSomething("abc"))
                .Callback(() => x = 10)
                .Returns(true)
                .Callback(() => y = 20);

            Assert.True(mock.Object.DoSomething("abc"));
            Assert.Equal(10, x);
            Assert.Equal(20, y);
        }
    }
}
