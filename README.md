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

### プロジェクトを作成(AWS)

```bash
# https://docs.aws.amazon.com/ja_jp/lambda/latest/dg/csharp-package-cli.html

# AWS Lambdaのテンプレートをインストール
$ dotnet new -i Amazon.Lambda.Templates
# AWS Extensions for .NET CLIのインストール...ビルドに必要
$ dotnet tool install -g Amazon.Lambda.Tools
# AWS .NET Mock Lambda Test Tool (Preview)のインストール...テストに必要
# .NET Core 3.1向け
$ dotnet tool install -g Amazon.Lambda.TestTool-3.1

#------------------------------------------------------------
# AWS Lambdaのプロジェクトを作成
$ dotnet new lambda.EmptyFunction --name [プロジェクト名]
$ dotnet new lambda.S3 --name [プロジェクト名]
$ dotnet new lambda.DynamoDB --name [プロジェクト名]

$ dotnet new lambda.EmptyFunction --name MyFunction --profile hogehoge --region ap-northeast-1
https://dotnetnew.azurewebsites.net/pack/Amazon.Lambda.Templates
```

## ソリューション

```bash
# ソリューションファイルを作成
$ dotnet new sln
# プロジェクトを追加
$ dotnet sln add [プロジェクトパス]
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

### 単体テストの実行

```bash
$ dotnet test
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
### dotnet-efをインストール

```bash
# グローバルにインストールする時
$ dotnet tool install --global dotnet-ef

# ローカルにインストールする時
$ dotnet new tool-manifest
$ dotnet tool install --local dotnet-ef

# バージョンの更新
$ dotnet tool update --global dotnet-ef
```

### インストールの確認

```bash
$ dotnet ef
```
### ツールの使用

コマンドは
* プロジェクト(現在のディレクトリのプロジェクト)
* スタートアッププロジェクト
を参照する

#### プロジェクト(現在のディレクトリのプロジェクト)
コマンドでファイルを追加または削除する場所
※プロジェクトは、--projectオプションをつけることで、ターゲットプロジェクトを指定できる

#### スタートアッププロジェクト
ツールによって構築され、実行されるプロジェクト
デザイン時、接続文字列やモデルの構成など、プロジェクトに関する情報を取得する必要がある

### データベースの削除

```bash
$ dotnet ef database drop
```

### データベースの更新

```bash
$ dotnet ef databse update
```

### DbContext型に関する情報を取得する

```bash
$ dotnet ef dbcontext info
```

### 使用可能なDbContext型を一覧表示

```bash
$ dotnet ef dbcontext list
```

### DbContextのコードとデータベースのエンティティ型を生成する

```bash
$ dotnet ef dbcontext scaffold
```

### 新し移行を追加する

```bash
$ dotnet ef migrations add
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