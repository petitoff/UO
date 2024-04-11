package pl.opole.uni.lista2.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.Urzadzenie;
import pl.opole.uni.lista2.model.Uzytkownik;

import java.util.List;

@Repository
public interface UzytkownikRepo extends JpaRepository<Uzytkownik,Integer> {
    @Query(value = "SELECT u FROM Uzytkownik u WHERE u.imie='Marcin' AND u.nazwisko='Nowak'")
    List<Uzytkownik> findMarcinNowakJPQL();

    @Query(value = "SELECT * FROM uzytkownik WHERE imie='Marcin' AND nazwisko='Nowak'",nativeQuery = true)
    List<Uzytkownik> findMarcinNowakSQL();

    @Query(value = "SELECT u FROM Uzytkownik u WHERE u.nazwisko LIKE 'K%' OR u.nazwisko LIKE 'N%'")
    List<Uzytkownik> findNazwiskoKNJPQL();

    @Query(value = "SELECT * FROM uzytkownik WHERE nazwisko LIKE 'K%' OR nazwisko LIKE 'N%'",nativeQuery = true)
    List<Uzytkownik> findNazwiskoKNSQL();
}
