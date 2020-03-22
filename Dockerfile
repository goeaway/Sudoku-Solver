FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

ARG app_publish_path

RUN mkdir {/sudoku,/sudoku/app,/sudoku/logs}

WORKDIR /sudoku/app

COPY app_publish_path /sudoku/app

EXPOSE 80
ENTRYPOINT [ "dotnet", "/sudoku/app/SudokuSolver.API.dll"]