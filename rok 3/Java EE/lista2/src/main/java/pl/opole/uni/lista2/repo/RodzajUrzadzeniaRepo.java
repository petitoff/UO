package pl.opole.uni.lista2.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.RodzajUrzadzenia;

import java.util.List;

@Repository
public interface RodzajUrzadzeniaRepo extends JpaRepository<RodzajUrzadzenia,Integer> {

    @Query(value = "SELECT r FROM RodzajUrzadzenia r WHERE r.nazwa LIKE 'D%'")
    List<RodzajUrzadzenia> findTypeOnDJPQL();
    @Query(value = "SELECT * From rodzaj_urzadzenia WHERE nazwa LIKE 'D%'", nativeQuery = true)
    List<RodzajUrzadzenia> findTypeOnDSQL();

}
