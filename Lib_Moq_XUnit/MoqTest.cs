using Lib_Moq_XUnit.Interface;
using Moq;
using System;
using Xunit;

namespace Lib_Moq_XUnit
{
    /// <summary>
    /// Moq�N���X���������e�X�g�ꗗ
    /// �Q�l�T�C�g:https://qiita.com/usamik26/items/42959d8b95397d3a8ffb
    /// </summary>
    public class MoqTest
    {
        [Fact]
        public void �Œ�l��Ԃ�()
        {
            var mock = new Mock<IHoge>();
            mock.SetupGet(x => x.Name)
                .Returns("xyz");
            Assert.Equal("xyz", mock.Object.Name);
        }

        [Fact]
        public void �l���Z�b�g����()
        {
            var mock = new Mock<IHoge>();
            mock.SetupProperty(x => x.Name, "xyz");
            Assert.Equal("xyz", mock.Object.Name);

            mock.Object.Name = "123";
            Assert.Equal("123", mock.Object.Name);
        }

        [Fact]
        public void ����̓��͂ɓ���̏o�͂�Ԃ�()
        {
            var mock = new Mock<IHoge>();
            mock.Setup(x => x.DoSomething("abc"))
                .Returns(true);
            Assert.True(mock.Object.DoSomething("abc"));
        }

        [Fact]
        public void ���͂̏������w�肷��()
        {
            var mock = new Mock<IHoge>();

            // 10���������ł����true��Ԃ�
            // It�ɂ͐F�X�ȃ��\�b�h������̂Ŋm�F����
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
        /// TODO:���������G���[�ɂȂ��Ă��܂��Ă���
        /// </summary>
        //[Fact]
        //public void ���͓��e�ɉ������o�͂�Ԃ�()
        //{
        //    var mock = new Mock<IHoge>();
        //    mock.Setup(x => x.DoSomething2(It.IsAny<string>()))
        //        .Returns(s => s.ToUpper());

        //    mock.Object.DoSomething("abc");
        //}

        [Fact]
        public void �v���p�e�B�̒�`���y�ɂ���()
        {
            var mock = new Mock<IHoge>();
            mock.SetupAllProperties();

            mock.Object.Name = "xyz";
            Assert.Equal("xyz", mock.Object.Name);
        }

        [Fact]
        public void ��O�𔭐�������()
        {
            var mock = new Mock<IHoge>();
            mock.Setup(x => x.DoSomething("abc"))
                .Throws<InvalidOperationException>();
            Assert.Throws<InvalidOperationException>(() => mock.Object.DoSomething("abc"));
        }

        [Fact]
        public void �Ԃ��l��ω�������()
        {
            var mock = new Mock<IHoge>();
            mock.SetupSequence(x => x.DoSomething("abc"))
                .Returns(true)
                .Returns(false)
                .Throws<InvalidOperationException>();

            // ���Ԃ�true, false, error�ƂȂ�
            Assert.True(mock.Object.DoSomething("abc"));
            Assert.False(mock.Object.DoSomething("abc"));
            Assert.Throws<InvalidOperationException>(() => mock.Object.DoSomething("abc"));
        }

        [Fact]
        public void �Ăяo���ꂽ���ǂ��������؂���()
        {
            var mock = new Mock<IHoge>();
            mock.Setup(x => x.DoSomething("abc"))
                .Returns(true);

            // ���Ȃ��Ƃ����Ăяo����Ă��邱��
            // �Ăяo����Ă��Ȃ������ꍇ�͗�O��f���o��
            try
            {
                mock.Verify(x => x.DoSomething("abc"), Times.AtLeastOnce());
                
                // �G���[��f���o���Ă��Ȃ���΂����Ńe�X�g���s�ɂȂ�
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
        public void �Ăяo���ꂽ�ۂ̏������L�q����()
        {
            var mock = new Mock<IHoge>();
            var x = 1;
            var y = 2;
            
            // Callback�ŏ��������s�����
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
