# CheetCSharp

## 目次
1. nugetのパッケージ
2. Visual Studio CodeでC#の環境を整える
3. 


## nugetのパッケージ
https://www.nuget.org/

## Visual Studio CodeでC#の環境を整える

参考URL
https://zenn.dev/midoliy/articles/9e3cff958ff89ba151de

### 導入プラグイン
* C# (required)
* VS Sharper for C# (required)
* Auto-Using for C# (optional)
* C# XML Documentaion Comments (optional)
* .Net Core Test Explorer (optional)
* Bookmarks (optional)
* Todo Tree (optional)
* NuGet Package Manager (optional)
* NuGet Reverse Package Search (optional)
* NuGet Gallery (optional)
* C# IL Viewer (optional)

## dotnetコマンド

### プロジェクトを作成
https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-new

```bash
# コンソールアプリ
$ dotnet new console --name [プロジェクト名]
# クラスライブラリ
$ dotnet new classlib --name [クラス名]
# Webアプリ(Razor)
$ dotnet new webapp --name [プロジェクト名]
# Webアプリ(MVC)
$ dotnet new mvc --name [プロジェクト名]
# WebAPI
$ dotnet new webapi --name [プロジェクト名]
# 単体テスト(XUnit)
$ dotnet new xunit --name [プロジェクト名]
```

### ビルド

```bash
$ dotnet build
```

### アプリケーションを実行

```bash
$ dotnet run 

# プロジェクト指定をする場合(カレントディレクトリと階層が違う場合)
$ dotnet run --project [プロジェクト名]

## 出力結果を見ると、
## https://localhost:5001
## http://localhost:5000
## のどちらかでアクセスできることがわかる

## ポート番号を指定する場合
# 8000番ポートを指定
$ dotnet run --urls http://*:8000/
```

### global.jsonを作成

```bash
# .NETのバージョンを指定できる
$ dotnet new globaljson
```

### .NETのバージョンを確認

```bash
$ dotnet --version
```

### .NETのインストール状況を確認

```bash
$ dotnet --info
```

## nugetを使う
1. 表示→コマンドパレット
2. NuGet Package Manager: Add Packageを選択
3. 使いたいnugetを使う

## dotnetコマンドの各種のツールのインストール

```bash
# グローバルにインストール
$ dotnet tool install --global [ツール名]

# ローカルにインストール
# .configを最初に作っておく
$ dotnet new tool-manifest
# その後インストール
$ dotnet tool install --local [ツール名]
```

## エンティティフレームワークを使う
1. dotnet-efをインストール

```bash
# グローバルにインストールする時
$ dotnet tool install --global dotnet-ef

# ローカルにインストールする時
$ dotnet new tool-manifest
$ dotnet tool install --local dotnet-ef
```

### パッケージのインストール/アンインストール

```bash
# インストール
$ dotnet add package [パッケージ名]
# アンインストール
$ dotnet remove package [パッケージ名]
```

## dotnet efコマンド

### 情報を表示

```bash
# バージョン、ヘルプを表示
$ dotnet ef
```

# スキャフォールド(DbContextクラスとEntityクラスを一気に作成する) 1361ページ

```bash
$ dotnet ef dbcontext scaffold
```



# デバッグ方法
https://docs.microsoft.com/ja-jp/dotnet/core/tutorials/debugging-with-visual-studio-code?pivots=dotnet-6-0