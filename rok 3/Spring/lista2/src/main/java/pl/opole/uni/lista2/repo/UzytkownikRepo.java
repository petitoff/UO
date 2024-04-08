package pl.opole.uni.lista2.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.Uzytkownik;

import java.util.List;

@Repository
public interface UzytkownikRepo extends JpaRepository<Uzytkownik,Integer> {
    List<Uzytkownik> findByImieEqualsAndNazwiskoEquals(String imie,String nazwisko);
    List<Uzytkownik> findByNazwiskoLikeOrNazwiskoLike(String like1,String like2);
}
