using static System.Console;
using System.Linq;
using University;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

var uni = new Universidade();

// var query = from dep in uni.Departamentos
//             orderby dep.Nome descending
//             select new {name = dep.Nome};


var query1 = from dep in uni.Departamentos
            join disc in uni.Disciplinas on dep.Id equals disc.DepartamentoId
            select new {dep, disc} into itens
            group itens by itens.dep.Nome into item
            orderby item.Key descending
            select new {name = $"{item.Key}", NumDisciplinas = item.Count()};
            

var query2 =  from aluno in uni.Alunos
            select new { aluno.Nome, aluno.Idade, Professores = (from materia in aluno.Matriculas
                join turma in uni.Turmas on materia equals turma.Id
                join prof in uni.Professores on turma.ProfessorId equals prof.Id 
                select prof.Nome
            ).Distinct().ToList()};
           

var query3 = from prof in uni.Professores
            join p in uni.Turmas on prof.Id equals p.ProfessorId
            select new { prof.Nome, prof.Salario, Alunos = (from aluno in uni.Alunos
                where aluno.Matriculas.Contains(p.Id)
                select aluno.Nome
            ).Distinct().ToList()} into itens
            group itens by new {itens.Nome, itens.Salario} into item
            select new {Nome = $"{item.Key.Nome}", Salario = $"{item.Key.Salario}", Alunos =  item.SelectMany(s => s.Alunos)};

            
var query4 = from prof in uni.Professores
            join p in uni.Turmas on prof.Id equals p.ProfessorId
            select new { prof.Nome, prof.Salario, Alunos = (from aluno in uni.Alunos
                where aluno.Matriculas.Contains(p.Id)
                select aluno.Nome
            ).Distinct().ToList()} into itens
            group itens by new {itens.Nome, itens.Salario} into item
            select new {Nome = $"{item.Key.Nome}", Salario = $"{item.Key.Salario}", Alunos =  item.SelectMany(s => s.Alunos).Count()} into fim
            orderby fim.Alunos descending 
            select fim;

var query5 = from aluno in uni.Alunos
            select new { aluno.Nome, aluno.Idade, Professores = (from materia in aluno.Matriculas
                join turma in uni.Turmas on materia equals turma.Id
                join prof in uni.Professores on turma.ProfessorId equals prof.Id 
                select prof.Salario
            ).ToList().Sum()};
              
// WriteLine("Os departamentos, em ordem alfabética, com o número de disciplinas.");
// foreach(var departamento in query1){
//     WriteLine("Departamento: " + departamento.name + " - " + "N° Disciplinas: " + departamento.NumDisciplinas);
// }

WriteLine("Liste os alunos e suas idades com seus respectivos professores.");
foreach(var aluno in query2){
    WriteLine("Nome: " +  aluno.Nome + " - Idade: " + aluno.Idade + " - Professores: " + string.Join("; ", aluno.Professores));
}


// WriteLine("Liste os professores e seus salários com seus respectivos alunos.");
// foreach(var prof in query3){
//     WriteLine("Professor: " + prof.Nome + " - Salário: " + prof.Salario + " - Alunos: " + string.Join("; ", prof.Alunos));
// }


// WriteLine("Top 5 Professores com mais alunos da universidade.");
// foreach(var prof in query4.Take(5)){
//     WriteLine("Professor: " + prof.Nome + " - Salário: " + prof.Salario + " - Qtd Alunos: " + string.Join("; ", prof.Alunos));
// }

WriteLine(
    """
    Considerando que todo aluno custa 300 reais mais o salário dos seus professores
    divido entre seus colegas de classe. Liste os alunos e seus respectivos custos.
    """
);
foreach(var aluno in query5.Take(5)){
    WriteLine("Aluno: " + aluno.Nome + " - Salário Profs: " + aluno.Professores);
}

ReadKey(true);