using Xunit;

namespace XUnitApp
{
    public class AssertUnitTest
    {
        /// <summary>
        /// Assertの種類について
        /// </summary>
        [Fact]
        public void AssertNullEmptyTest()
        {
            //NULLチェック
            string? strNull = null;
            Assert.Null(strNull);

            //NOT NULLチェック
            string strNotNull = "NotNull";
            Assert.NotNull(strNotNull);

            //空チェック
            string strEmpty = "";
            Assert.Empty(strEmpty);

            //NOT 空チェック
            string strNotEmpty = "NotEmpty";
            Assert.NotEmpty(strNotEmpty);
        }

        [Fact]
        public void AssertEqualTest()
        {
            //Equalチェック
            string strEqual1 = "ABC";
            string strEqual2 = "abc";

            //ignoreCase: true に設定すると、大文字小文字が異なっていてもエラーとしない。
            //ignoreLineEndingDifferences: true に設定すると、改行コード（\r\n, \r, \n）が異なる場合でもエラーとしない。
            //ignoreWhiteSpaceDifferences: ture に設定すると、スペースの数やスペースじゃなくてタブでもエラーとしない
            //（スペースがある前提での評価で、スペースがあるものとないものを評価すればエラーになります）。
            Assert.Equal(strEqual1, strEqual2, ignoreCase: true);

            //NotEqualチェック
            string strNotEqual1 = "ABC";
            string strNotEqual2 = "def";
            Assert.NotEqual(strNotEqual1, strNotEqual2);
        }
    }
}