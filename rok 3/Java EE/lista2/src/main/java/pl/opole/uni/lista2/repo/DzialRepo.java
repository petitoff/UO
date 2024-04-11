package pl.opole.uni.lista2.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.Dzial;
import pl.opole.uni.lista2.model.Producent;

import java.util.List;

@Repository
public interface DzialRepo extends JpaRepository<Dzial,Integer> {
    @Query(value = "SELECT d FROM Dzial d WHERE d.nazwa LIKE '%ing'")
    List<Dzial> findEndingJPQL();

    @Query(value = "SELECT * FROM dzial WHERE nazwa LIKE '%ing'",nativeQuery = true)
    List<Dzial> findEndingSQL();
}
