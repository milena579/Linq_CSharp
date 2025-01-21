namespace University;

public record Professor(
    int Id,
    string Nome,
    int Idade,
    int DepartamentoId,
    decimal Salario
);

public record Departamento(
    int Id, 
    string Nome
);

public record Disciplina(
    int Id,
    string Nome,
    int DepartamentoId
);

public record Turma(
    int Id,
    int DisciplinaId,
    int ProfessorId,
    string Codigo
);

public record Aluno(
    int Id,
    string Nome,
    int Idade,
    List<int> Matriculas
);

public class Universidade
{
    public readonly IEnumerable<Departamento> Departamentos = [
        new(1, "DAMAT"), new(2, "DAFIS"), new(3, "DAINF"), new(4, "DAELN")
    ];

    public readonly IEnumerable<Disciplina> Disciplinas = [
        new(1, "Cálculo 1", 1), new(2, "Cálculo 2", 1), new(3, "Cálculo 3", 1), 
        new(4, "Física 1", 2), new(5, "Física 2", 2), new(6, "Física 3", 2), 
        new(7, "Técnicas de Programação 1", 3), new(8, "Técnicas de Programação 2", 3), 
        new(9, "Eletricidade", 4), new(10, "Oficinas de Integração", 4)
    ];

    public readonly IEnumerable<Professor> Professores = [
        new(1, "Fábio Dorini", 34, 1, 11_000),
        new(2, "Inácio", 45, 1, 14_000),
        new(3, "Roni", 38, 1, 10_000),
        new(4, "Leiza Dorini", 34, 3, 10_000),
        new(5, "Rafael Barreto", 29, 2, 15_000),
        new(6, "Bogdan Nassu", 32, 3, 17_000),
        new(7, "Bogado", 43, 3, 9_000),
        new(8, "Cezar Sanchez", 35, 4, 14_000),
        new(9, "Razera", 28, 4, 12_000)
    ];

    public readonly IEnumerable<Turma> Turmas = [
        new(1, 1, 1, "S71"), new(2, 2, 2, "S71"),
        new(3, 3, 3, "S71"), new(4, 4, 5, "S71"),
        new(5, 5, 5, "S71"), new(6, 6, 5, "S71"),
        new(7, 7, 6, "S71"), new(8, 8, 7, "S71"),
        new(9, 9, 9, "S71"), new(10, 10, 8, "S71"),
        new(11, 1, 2, "S73"), new(12, 7, 4, "S73")
    ];

    public readonly IEnumerable<Aluno> Alunos = [
        new(1, "Leonardo Trevisan Silio", 18, [ 3, 4, 8, 9 ]),
        new(2, "Bruna Pinheirinho", 18, [ 2, 6, 10 ]),
        new(3, "Alan Jun Onoda", 18, [ 2, 5, 7 ]),
        new(4, "Ian Douglas", 20, [ 3, 6, 10 ]),
        new(5, "Jordão Vyctor", 19, [ 3, 11, 12 ])
    ];
}